using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web.Http;
using System.Web.Http.Results;
using System;

namespace MoneyFlow.Common.HttpResults
{
    /// <summary>
    /// Represents an action result that returns an <see cref="HttpStatusCode.OK"/> response with JSON data.
    /// </summary>
    /// <typeparam name="T">The type of content in the entity body.</typeparam>
    public class CustomResult<T> : JsonResult<T>
    {
        public CustomResult() {

        }
    }
}
