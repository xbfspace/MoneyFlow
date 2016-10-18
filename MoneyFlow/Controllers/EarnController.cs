using MoneyFlow.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoneyFlow.Controllers
{
    public class EarnController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage AddEarn(EarnDTO model) {
            if (ModelState.IsValid)
            {
                //do add to db
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
