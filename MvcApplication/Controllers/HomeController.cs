using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using OAuthTwitterTimeLine;

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
            var oAuthTwitterTimeline = new OAuthTwitterTimeline();
            return Json(oAuthTwitterTimeline.GetMyTimeline(), JsonRequestBehavior.AllowGet);
        }
    }
}
