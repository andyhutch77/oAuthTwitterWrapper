using System.Configuration;
using System;
using System.Threading.Tasks;
using OAuthTwitterWrapper.JsonTypes;

namespace OAuthTwitterWrapper
{
	public class OAuthTwitterWrapper : IOAuthTwitterWrapper
    {
		public IAuthenticateSettings AuthenticateSettings { get; set; }
		public ITimeLineSettings TimeLineSettings { get; set; }
		public ISearchSettings SearchSettings { get; set; }

        /// <summary>
        /// This constructor takes most of the settings from the appsettings file apart from consumer key and consumer secret. If not filled in, there are defaults.
        /// </summary>
        public OAuthTwitterWrapper(string oAuthConsumerKey, string oAuthConsumerSecret, string screenName)
		{
            AuthenticateSettings = new AuthenticateSettings
			{
			    OAuthConsumerKey = oAuthConsumerKey,
                OAuthConsumerSecret = oAuthConsumerSecret,
                OAuthUrl = ConfigurationManager.AppSettings["oAuthUrl"] ?? "https://api.twitter.com/oauth2/token"
            };
			
			TimeLineSettings = new TimeLineSettings
			{
				ScreenName = screenName,
				IncludeRts = ConfigurationManager.AppSettings["include_rts"] ?? "1",
				ExcludeReplies = ConfigurationManager.AppSettings["exclude_replies"] ?? "0",
				Count = Convert.ToInt16(ConfigurationManager.AppSettings["count"] ?? "10"),
				TimelineFormat = ConfigurationManager.AppSettings["timelineFormat"] ?? "https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name={0}&amp;include_rts={1}&amp;exclude_replies={2}&amp;count={3}"
            };

            SearchSettings = new SearchSettings
			{
				SearchFormat = ConfigurationManager.AppSettings["searchFormat"] ?? "https://api.twitter.com/1.1/search/tweets.json?q={0}",
				SearchQuery = ConfigurationManager.AppSettings["searchQuery"]
            };

		}

        /// <summary>
        /// The default constructor takes all the settings from the appsettings file
        /// </summary>
        public OAuthTwitterWrapper() : this(ConfigurationManager.AppSettings["oAuthConsumerKey"], ConfigurationManager.AppSettings["oAuthConsumerSecret"], ConfigurationManager.AppSettings["screenname"])
        {
        }

        /// <summary>
        /// This allows the authentications settings to be passed in
        /// </summary>
        /// <param name="authenticateSettings"></param>
        public OAuthTwitterWrapper(IAuthenticateSettings authenticateSettings)
		{
			AuthenticateSettings = authenticateSettings;
		}

		/// <summary>
		/// This allows the authentications and timeline settings to be passed in
		/// </summary>
		/// <param name="authenticateSettings"></param>
		/// <param name="timeLineSettings"></param>
		public OAuthTwitterWrapper(IAuthenticateSettings authenticateSettings, ITimeLineSettings timeLineSettings)
		{
			AuthenticateSettings = authenticateSettings;
			TimeLineSettings = timeLineSettings;
		}

		/// <summary>
		/// This allows the authentications, timeline and search settings to be passed in
		/// </summary>
		/// <param name="authenticateSettings"></param>
		/// <param name="timeLineSettings"></param>
		/// <param name="searchSettings"></param>
		public OAuthTwitterWrapper(IAuthenticateSettings authenticateSettings, ITimeLineSettings timeLineSettings, ISearchSettings searchSettings)
		{
			AuthenticateSettings = authenticateSettings;
			TimeLineSettings = timeLineSettings;
			SearchSettings = searchSettings;
		}

        public Task<string> GetMyTimelineAsync()
        {
            IAuthenticate authenticate = new Authenticate();
            AuthResponse twitAuthResponse = authenticate.AuthenticateMe(AuthenticateSettings);

            var utility = new Utility();
            return utility.RequstJsonAsync(TimeLineSettings.TimelineUrl, twitAuthResponse.TokenType, twitAuthResponse.AccessToken);
        }

        public string GetMyTimeline()
        {
            IAuthenticate authenticate = new Authenticate();
			AuthResponse twitAuthResponse = authenticate.AuthenticateMe(AuthenticateSettings);

            var utility = new Utility();
            return utility.RequstJson(TimeLineSettings.TimelineUrl, twitAuthResponse.TokenType, twitAuthResponse.AccessToken);
        }

		public string GetSearch()
		{
			IAuthenticate authenticate = new Authenticate();
			AuthResponse twitAuthResponse = authenticate.AuthenticateMe(AuthenticateSettings);

			var utility = new Utility();
            return utility.RequstJson(SearchSettings.SearchUrl, twitAuthResponse.TokenType, twitAuthResponse.AccessToken);
		}
    }
}
