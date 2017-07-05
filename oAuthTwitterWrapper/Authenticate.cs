using System;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using OAuthTwitterWrapper.JsonTypes;

namespace OAuthTwitterWrapper
{
	internal class Authenticate : IAuthenticate
	{
		public AuthResponse AuthenticateMe(IAuthenticateSettings authenticateSettings)
		{
			AuthResponse twitAuthResponse;
			const string authHeaderFormat = "Basic {0}";

			var authHeader = string.Format(authHeaderFormat,
										   Convert.ToBase64String(
											   Encoding.UTF8.GetBytes(Uri.EscapeDataString(authenticateSettings.OAuthConsumerKey) + ":" +

																	  Uri.EscapeDataString((authenticateSettings.OAuthConsumerSecret)))

											   ));
			var postBody = "grant_type=client_credentials";
			var authRequest = (HttpWebRequest)WebRequest.Create(authenticateSettings.OAuthUrl);

			authRequest.Headers.Add("Authorization", authHeader);
			authRequest.Method = "POST";
			authRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
			authRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
			using (var stream = authRequest.GetRequestStream())
			{
				var content = Encoding.ASCII.GetBytes(postBody);
				stream.Write(content, 0, content.Length);
			}
			authRequest.Headers.Add("Accept-Encoding", "gzip");
			var authResponse = authRequest.GetResponse();
			// deserialize into an object
			using (authResponse)
			{
				using (var response = authResponse.GetResponseStream())
				{
                    var reader = new StreamReader(response, Encoding.UTF8);
                    var objectText = reader.ReadToEnd();					
					twitAuthResponse = JsonConvert.DeserializeObject<AuthResponse>(objectText);
				}
			}

			return twitAuthResponse;
		}
	}
}
