using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuthTwitterSearch
{
	public class TwitAuthenticateResponse
	{
		public string token_type { get; set; }
		public string access_token { get; set; }
	}
}
