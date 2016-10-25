using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;

namespace MoneyFlow.Common.Extensions
{
    public static class CustomApiControllerExtension
    {
        public static IHttpActionResult Success(this ApiController controller,object data) {
            return new JsonResult<SuccessResult>(new SuccessResult { Data=data}, new Newtonsoft.Json.JsonSerializerSettings(), new UTF8Encoding(encoderShouldEmitUTF8Identifier: false,
                throwOnInvalidBytes: true),controller);
            //return new OkNegotiatedContentResult<SuccessResult>(new SuccessResult { Data = data }, controller);
        }
        public static IHttpActionResult Error(this ApiController controller,string errorMessage) {
            return new JsonResult<ErrorResult>(new ErrorResult { ErrorMsg=errorMessage,ErrorCode=(int)HttpStatusCode.InternalServerError }, new Newtonsoft.Json.JsonSerializerSettings(), new UTF8Encoding(encoderShouldEmitUTF8Identifier: false,
              throwOnInvalidBytes: true), controller);
            //return new NegotiatedContentResult<ErrorResult>(HttpStatusCode.InternalServerError, new ErrorResult() { ErrorMsg = errorMessage, ErrorCode = (int)HttpStatusCode.InternalServerError }, controller);
        }

        internal class SuccessResult {
            internal object Data { get; set; }
           internal bool Success { get { return true; } }
        }
        internal class ErrorResult {
            internal int ErrorCode { get; set; }
            internal string ErrorMsg { get; set; }
            internal bool Success { get { return false; } }
        }

    }

   
}