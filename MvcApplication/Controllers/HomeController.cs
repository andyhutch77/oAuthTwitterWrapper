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
		private readonly IOAuthTwitterWrapper _oAuthTwitterWrapper;

		public HomeController(IOAuthTwitterWrapper oAuthTwitterWrapper)
		{
			_oAuthTwitterWrapper = oAuthTwitterWrapper;
		}

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetTwitterFeed()
        {
			return Json(_oAuthTwitterWrapper.GetMyTimeline(), JsonRequestBehavior.AllowGet);
        }


        public ActionResult Deserialized()
        {
			var json = _oAuthTwitterWrapper.GetMyTimeline();
            var result = JsonConvert.DeserializeObject<List<TimeLine>>(json);
            return View(result);
        }

        public ActionResult DeserializedSearch()
        {
			var json = _oAuthTwitterWrapper.GetSearch();
            var result = JsonConvert.DeserializeObject<Search>(json);
            return View(result);
        }
    }
}
