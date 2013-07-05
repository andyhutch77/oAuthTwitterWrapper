using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OAuthTwitterWrapper.JsonTypes
{

    public class Entities2
    {

        [JsonProperty("hashtags")]
		public List<string> Hashtags { get; set; }

        [JsonProperty("symbols")]
		public List<string> Symbols { get; set; }

        [JsonProperty("urls")]
		public List<string> Urls { get; set; }

        [JsonProperty("user_mentions")]
		public List<string> UserMentions { get; set; }
    }

}
