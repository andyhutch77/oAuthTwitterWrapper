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

namespace OAuthTwitterTimeLine
{
    public class OAuthTwitterTimeline
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

        public string GetMyTimeline()
        {
            // Do the Authenticate
            var authHeaderFormat = "Basic {0}";

            var authHeader = string.Format(authHeaderFormat,
                                           Convert.ToBase64String(
                                               Encoding.UTF8.GetBytes(Uri.EscapeDataString(oAuthConsumerKey) + ":" +

                                                                      Uri.EscapeDataString((oAuthConsumerSecret)))

                                               ));
            var postBody = "grant_type=client_credentials";
            HttpWebRequest authRequest = (HttpWebRequest)WebRequest.Create(oAuthUrl);

            authRequest.Headers.Add("Authorization", authHeader);
            authRequest.Method = "POST";
            authRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            authRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            using (Stream stream = authRequest.GetRequestStream())
            {
                byte[] content = ASCIIEncoding.ASCII.GetBytes(postBody);
                stream.Write(content, 0, content.Length);
            }
            authRequest.Headers.Add("Accept-Encoding", "gzip");
            WebResponse authResponse = authRequest.GetResponse();
            // deserialize into an object
            TwitAuthenticateResponse twitAuthResponse;
            using (authResponse)
            {
                using (var reader = new StreamReader(authResponse.GetResponseStream()))
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var objectText = reader.ReadToEnd();
                    twitAuthResponse = JsonConvert.DeserializeObject<TwitAuthenticateResponse>(objectText);
                }
            }

            // Do the timeline
            HttpWebRequest timeLineRequest = (HttpWebRequest)WebRequest.Create(timelineUrl);
            var timelineHeaderFormat = "{0} {1}";
            timeLineRequest.Headers.Add("Authorization",
                                        string.Format(timelineHeaderFormat, twitAuthResponse.token_type,
                                                      twitAuthResponse.access_token));
            timeLineRequest.Method = "Get";
            WebResponse timeLineResponse = timeLineRequest.GetResponse();

            var timeLineJson = string.Empty;
            using (authResponse)
            {
                using (var reader = new StreamReader(timeLineResponse.GetResponseStream()))
                {
                    timeLineJson = reader.ReadToEnd();
                }
            }
            return timeLineJson;
        }
    }
}
