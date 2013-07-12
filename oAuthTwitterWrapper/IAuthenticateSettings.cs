using System;
namespace OAuthTwitterWrapper
{
	public interface IAuthenticateSettings
	{
		string OAuthConsumerKey { get; set; }
		string OAuthConsumerSecret { get; set; }
		string OAuthUrl { get; set; }
	}
}
