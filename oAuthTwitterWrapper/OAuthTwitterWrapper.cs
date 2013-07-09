using System.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using oAuthTwitterWrapper;
using OAuthTwitterWrapper.JsonTypes;

namespace OAuthTwitterWrapper
{
	public class OAuthTwitterWrapper : IOAuthTwitterWrapper
    {
        private string oAuthConsumerKey = ConfigurationManager.AppSettings["oAuthConsumerKey"];
        private string oAuthConsumerSecret = ConfigurationManager.AppSettings["oAuthConsumerSecret"];
        private string oAuthUrl = ConfigurationManager.AppSettings["oAuthUrl"];
        private static string screenname = ConfigurationManager.AppSettings["screenname"];
        private static string include_rts = ConfigurationManager.AppSettings["include_rts"];
        private static string exclude_replies = ConfigurationManager.AppSettings["exclude_replies"];
        private static string count = ConfigurationManager.AppSettings["count"];
        private static string timelineFormat = ConfigurationManager.AppSettings["timelineFormat"];
        private string timelineUrl = string.Format(timelineFormat, screenname, include_rts, exclude_replies, count);
		private static string searchFormat = ConfigurationManager.AppSettings["searchFormat"];
		private static string searchQuery = ConfigurationManager.AppSettings["searchQuery"];
		private string searchUrl = string.Format(searchFormat, searchQuery);

        public string GetMyTimeline()
        {
			var timeLineJson = string.Empty;
			var authenticate = new Authenticate();
			AuthResponse twitAuthResponse = authenticate.AuthenticateMe(oAuthConsumerKey, oAuthConsumerSecret, oAuthUrl);

            // Do the timeline
			var utility = new Utility();
			timeLineJson = utility.RequstJson(timelineUrl, twitAuthResponse.TokenType, twitAuthResponse.AccessToken);
            
            return timeLineJson;
        }

		public string GetSearch()
		{
			var searchJson = string.Empty;
			var authenticate = new Authenticate();
			AuthResponse twitAuthResponse = authenticate.AuthenticateMe(oAuthConsumerKey, oAuthConsumerSecret, oAuthUrl);

			// Do the timeline
			var utility = new Utility();
			searchJson = utility.RequstJson(searchUrl, twitAuthResponse.TokenType, twitAuthResponse.AccessToken);

			return searchJson;
		}
    }
}
