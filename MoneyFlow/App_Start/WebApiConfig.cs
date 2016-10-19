using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using MoneyFlow.Models.Filters;
using System.Web.Http.Controllers;
using MoneyFlow.Common;
using System.Web.Http.ModelBinding.Binders;
using System.Web.Http.ModelBinding;

namespace MoneyFlow
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            // 将 Web API 配置为仅使用不记名令牌身份验证。
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //config.Routes.MapHttpRoute(
            //name: "DefaultApi",
            //routeTemplate: "api/{controller}/{action}/{id}",
            //defaults: new { controller="Home" ,action="Index", id = RouteParameter.Optional }
            //);
            //移除xml支持，仅保留json格式支持
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            //循环引用对象序列化处理
            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.All;
            //添加model校验
            config.Filters.Add(new ValidateModelAttribute());

            //这里实现自定义参数绑定规则action model值绑定 webapi 源码中action参数的绑定顺序为1、attribute 如[FromUri] 2、ParameterBindingRules 3、简单类型[FromUri] 复杂类型[FromBody]
            config.ParameterBindingRules.Add(MyRequestParameterBingRule.RuleInstance);
            //config.Services.Replace(typeof(IActionValueBinder), new MyActionValueBinder());
        }
    }
}
