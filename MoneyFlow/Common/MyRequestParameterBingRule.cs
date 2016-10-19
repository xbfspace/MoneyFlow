using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;

namespace MoneyFlow.Common
{
    public class MyRequestParameterBingRule
    {
        public static HttpParameterBinding RuleInstance(HttpParameterDescriptor descriptor) {
            return descriptor.BindWithModelBinding(new MyRequestParameterValueProviderFactory());
        }
    }
}