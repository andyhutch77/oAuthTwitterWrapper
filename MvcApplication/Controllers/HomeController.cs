using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Newtonsoft.Json;
using OAuthTwitterWrapper;
using OAuthTwitterWrapper.JsonTypes;

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


        public ActionResult Deserialized()
        {
            var oAuthTwitterWrapper = new OAuthTwitterWrapper.OAuthTwitterWrapper();
            var json = oAuthTwitterWrapper.GetMyTimeline();
            var result = JsonConvert.DeserializeObject<List<TimeLine>>(json);
            return View(result);
        }

        public ActionResult DeserializedSearch()
        {
            var oAuthTwitterWrapper = new OAuthTwitterWrapper.OAuthTwitterWrapper();
            var json = oAuthTwitterWrapper.GetSearch();
            var result = JsonConvert.DeserializeObject<Search>(json);
            return View(result);
        }
    }
}
