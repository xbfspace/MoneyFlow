using MoneyFlow.DAL;
using MoneyFlow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyFlow.BLL.Impl
{
    public class EarnBusiness:IEarnBusiness
    {
        private EarnDal earnDal = new EarnDal();
        public int Add(Earn model)
        {
            return earnDal.Add(model);
        }
    }
}