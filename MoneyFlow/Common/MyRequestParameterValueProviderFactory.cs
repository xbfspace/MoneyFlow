using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.ValueProviders;
using System.Web.Http.ValueProviders.Providers;
using System.Web.Script.Serialization;
namespace MoneyFlow.Common
{
    public class MyRequestParameterValueProviderFactory:ValueProviderFactory
    {
        private const string RequestContentLocalStorageKey = "{EA48072C-FA31-4D67-8282-159B79CF53E4}";

        public override IValueProvider GetValueProvider(HttpActionContext actionContext)
        {
            IValueProvider provider;
            IDictionary<string, object> storage = actionContext.Request.Properties;

            if (!TryGetValue<IValueProvider>(storage, RequestContentLocalStorageKey, out provider))
            {
                var contentType = actionContext.Request.Content.Headers.ContentType;
                if (contentType == null)
                {
                    provider = null;
                }
                else if (contentType.MediaType == "application/x-www-form-urlencoded")
                {
                    var nv = actionContext.Request.Content.ReadAsFormDataAsync().Result;

                    provider = new NameValuePairsValueProvider(ToDictionary(nv), CultureInfo.CurrentCulture);
                }
                else if (contentType.MediaType == "application/json")
                {
                    object jsonData = GetDeserializedObject(actionContext);
                    if (jsonData == null)
                    {
                        return null;
                    }

                    Dictionary<string, object> backingStore = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
                    EntryLimitedDictionary backingStoreWrapper = new EntryLimitedDictionary(backingStore);
                    AddToBackingStore(backingStoreWrapper, String.Empty, jsonData);
                    provider = new NameValuePairsValueProvider(backingStore, CultureInfo.CurrentCulture);

                }
                else if (contentType.MediaType == "multipart/form-data")
                {
                    IEnumerable<HttpContent> bodyparts = null;
                    Task.Factory.StartNew(() => bodyparts = actionContext.Request.Content.ReadAsMultipartAsync().Result.Contents,
                            CancellationToken.None,
                            TaskCreationOptions.LongRunning, // guarantees separate thread
                            TaskScheduler.Default)
                        .Wait();
                    var multipartKV = new Dictionary<string, object>();

                    foreach (var bodypart in bodyparts)
                    {
                        if (bodypart.Headers.ContentType == null)
                        {
                            multipartKV.Add(bodypart.Headers.ContentDisposition.Name.Replace("\"", ""), bodypart.ReadAsStringAsync().Result);
                        }
                        else
                        {
                            if (!string.IsNullOrWhiteSpace(bodypart.Headers.ContentDisposition.FileName))
                            {
                                multipartKV.Add("FileName", bodypart.Headers.ContentDisposition.FileName.Replace("\"", ""));
                                multipartKV.Add("InputStream", bodypart.ReadAsStreamAsync().Result);
                                multipartKV.Add("ContentLength", bodypart.Headers.ContentLength);
                                multipartKV.Add("ContentType", bodypart.Headers.ContentType);
                            }

                        }
                    }
                    provider = new NameValuePairsValueProvider(multipartKV, CultureInfo.CurrentCulture);


                }
                storage[RequestContentLocalStorageKey] = provider;
            }

            return provider;

        }

        private bool TryGetValue<T>(IDictionary<string, object> collection, string key, out T value)
        {


            object valueObj;
            if (collection.TryGetValue(key, out valueObj))
            {
                if (valueObj is T)
                {
                    value = (T)valueObj;
                    return true;
                }
            }

            value = default(T);
            return false;
        }
        private IDictionary<string, string> ToDictionary(NameValueCollection col)
        {
            IDictionary<string, string> dict = new Dictionary<string, string>();
            foreach (var k in col.AllKeys)
            {
                dict.Add(k, col[k]);
            }
            return dict;
        }

        private object GetDeserializedObject(HttpActionContext actionContext)
        {


            var stream = actionContext.Request.Content.ReadAsStreamAsync().Result;
            if (stream.CanSeek)
            {
                stream.Position = 0;
            }
            StreamReader reader = new StreamReader(stream);
            string bodyText = reader.ReadToEnd();
            if (String.IsNullOrEmpty(bodyText))
            {
                // no JSON data
                return null;
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            object jsonData = serializer.DeserializeObject(bodyText);
            return jsonData;
        }

        private static void AddToBackingStore(EntryLimitedDictionary backingStore, string prefix, object value)
        {
            IDictionary<string, object> d = value as IDictionary<string, object>;
            if (d != null)
            {
                foreach (KeyValuePair<string, object> entry in d)
                {
                    AddToBackingStore(backingStore, MakePropertyKey(prefix, entry.Key), entry.Value);
                }
                return;
            }

            IList l = value as IList;
            if (l != null)
            {
                for (int i = 0; i < l.Count; i++)
                {
                    AddToBackingStore(backingStore, MakeArrayKey(prefix, i), l[i]);
                }
                return;
            }

            // primitive
            backingStore.Add(prefix, value);
        }
        private static string MakePropertyKey(string prefix, string propertyName)
        {
            return (String.IsNullOrEmpty(prefix)) ? propertyName : prefix + "." + propertyName;
        }

        private static string MakeArrayKey(string prefix, int index)
        {
            return prefix + "[" + index.ToString(CultureInfo.InvariantCulture) + "]";
        }
        private class EntryLimitedDictionary
        {
            private static int _maximumDepth = GetMaximumDepth();
            private readonly IDictionary<string, object> _innerDictionary;
            private int _itemCount = 0;

            public EntryLimitedDictionary(IDictionary<string, object> innerDictionary)
            {
                _innerDictionary = innerDictionary;
            }

            public void Add(string key, object value)
            {
                if (++_itemCount > _maximumDepth)
                {
                    throw new InvalidOperationException("请求内容太长");
                }

                _innerDictionary.Add(key, value);
            }

            private static int GetMaximumDepth()
            {

                return 1000; // Fallback default
            }
        }
    }
}