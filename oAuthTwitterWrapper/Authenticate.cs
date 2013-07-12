using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using OAuthTwitterWrapper;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.IO;
using OAuthTwitterWrapper.JsonTypes;

namespace OAuthTwitterWrapper
{
	class Authenticate : IAuthenticate
	{
		public AuthResponse AuthenticateMe(IAuthenticateSettings authenticateSettings)
		{
			AuthResponse twitAuthResponse = null;
			// Do the Authenticate
			var authHeaderFormat = "Basic {0}";

			var authHeader = string.Format(authHeaderFormat,
										   Convert.ToBase64String(
											   Encoding.UTF8.GetBytes(Uri.EscapeDataString(authenticateSettings.OAuthConsumerKey) + ":" +

																	  Uri.EscapeDataString((authenticateSettings.OAuthConsumerSecret)))

											   ));
			var postBody = "grant_type=client_credentials";
			HttpWebRequest authRequest = (HttpWebRequest)WebRequest.Create(authenticateSettings.OAuthUrl);

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
			using (authResponse)
			{
				using (var reader = new StreamReader(authResponse.GetResponseStream()))
				{
					JavaScriptSerializer js = new JavaScriptSerializer();
					var objectText = reader.ReadToEnd();					
					twitAuthResponse = JsonConvert.DeserializeObject<AuthResponse>(objectText);
				}
			}

			return twitAuthResponse;
		}
	}
}
