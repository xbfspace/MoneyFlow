using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace MoneyFlow.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(Duration = 36000, Location = OutputCacheLocation.Any)]
        public ActionResult Redirect()
        {
            return Redirect("/home/");
        }
    }

}