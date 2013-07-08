using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OAuthTwitterWrapper.JsonTypes
{

    public class Media
    {

        public object id { get; set; }
        public string id_str { get; set; }
        public List<int> indices { get; set; }
        public string media_url { get; set; }
        public string media_url_https { get; set; }
        public string url { get; set; }
        public string display_url { get; set; }
        public string expanded_url { get; set; }
        public string type { get; set; }
        public Sizes sizes { get; set; }
    }

    public class Sizes
    {
        public Thumb thumb { get; set; }
        public Small small { get; set; }
        public Medium medium { get; set; }
        public Large large { get; set; }
    }
    public class Thumb
    {
        public int w { get; set; }
        public int h { get; set; }
        public string resize { get; set; }
    }

    public class Small
    {
        public int w { get; set; }
        public int h { get; set; }
        public string resize { get; set; }
    }

    public class Medium
    {
        public int w { get; set; }
        public int h { get; set; }
        public string resize { get; set; }
    }

    public class Large
    {
        public int w { get; set; }
        public int h { get; set; }
        public string resize { get; set; }
    }

}
