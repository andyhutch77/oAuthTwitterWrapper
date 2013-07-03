using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using OAuthTwitterWrapper;

namespace MvcApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetTwitterFeed()
        {
            var oAuthTwitterWrapper = new OAuthTwitterWrapper.OAuthTwitterWrapper();
            return Json(oAuthTwitterWrapper.GetMyTimeline(), JsonRequestBehavior.AllowGet);
        }
    }
}
