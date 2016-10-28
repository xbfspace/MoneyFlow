using MoneyFlow.Models.DTO;
using System.Web.Http;
using MoneyFlow.Common.Extensions;
using MoneyFlow.Common.Controllers;
using System;
using Nelibur.ObjectMapper;
using MoneyFlow.Models;
using MoneyFlow.BLL;
using MoneyFlow.BLL.Impl;
using MoneyFlow.Common;

namespace MoneyFlow.Controllers
{
    public class EarnController : BaseApiController
    {
        private IEarnBusiness earnBusiness = new EarnBusiness();

        [HttpPost]
        public IHttpActionResult AddEarn(EarnDTO model) {
            TinyMapper.Bind<EarnDTO, Earn>();
            var entity = TinyMapper.Map<Earn>(model);
            entity.Id = IdGenerator.GetId();
            earnBusiness.Add(entity);
           // var tt=this.Success("add success");
            //return tt;
           return this.Success("add success");
        }

        [HttpGet]
        public IHttpActionResult GetEarn(int id) {
            try
            {
                var model = new EarnDTO
                {
                    Id = 1,
                    Amount = 100,
                    Content = "寸土寸金",
                    EarnDate = DateTime.Now
                };
                return this.Success(model);
            }
            catch (Exception ex)
            {
                return this.Error(ex.Message);
            }
        }
    }
}
