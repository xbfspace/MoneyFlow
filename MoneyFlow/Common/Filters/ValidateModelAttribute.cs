using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;

namespace MoneyFlow.Models.Filters
{
    /// <summary>
    /// 对api控制器中的实体参数进行验证  无需再每个控制器中调用ModelState.IsValid进行模型校验，App_Start>WebApiConfig.c全局配置config.Filters.Add(new ValidateModelAttribute());
    /// </summary>
    public class ValidateModelAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ModelState.IsValid == false)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, actionContext.ModelState);
            }
        }
    }
}