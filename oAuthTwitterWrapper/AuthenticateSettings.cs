namespace OAuthTwitterWrapper
{
	public class AuthenticateSettings : IAuthenticateSettings
	{
		public string OAuthConsumerKey { get; set; }
		public string OAuthConsumerSecret { get; set; }
		public string OAuthUrl { get; set; }
	}
}
