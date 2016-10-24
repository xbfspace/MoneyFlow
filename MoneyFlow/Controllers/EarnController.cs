using MoneyFlow.Models.DTO;
using System.Web.Http;
using MoneyFlow.Common.Extensions;
using MoneyFlow.Common.Controllers;
using System;
using Nelibur.ObjectMapper;
using MoneyFlow.Models;

namespace MoneyFlow.Controllers
{
    public class EarnController : BaseApiController
    {
        [HttpPost]
        public IHttpActionResult AddEarn(EarnDTO model) {
            TinyMapper.Bind<EarnDTO, Earn>();
            var modelToSave = TinyMapper.Map<Earn>(model);
            return this.Success(new { hh = "你发多少" });
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
