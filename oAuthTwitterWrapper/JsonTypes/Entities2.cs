using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OAuthTwitterWrapper.JsonTypes
{

    public class Entities2
    {

        [JsonProperty("hashtags")]
        public object[] Hashtags { get; set; }

        [JsonProperty("symbols")]
        public object[] Symbols { get; set; }

        [JsonProperty("urls")]
        public object[] Urls { get; set; }

        [JsonProperty("user_mentions")]
        public object[] UserMentions { get; set; }
    }

}
