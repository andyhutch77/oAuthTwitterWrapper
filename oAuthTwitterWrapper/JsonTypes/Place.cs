namespace oAuthTwitterWrapper.JsonTypes
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class Place
    {

        //"id":"778909dfad43f3d6",
        //"url":"https:\/\/api.twitter.com\/1.1\/geo\/id\/778909dfad43f3d6.json",
        //"place_type":"city",
        //"name":"Huddersfield",
        //"full_name":"Huddersfield, England",
        //"country_code":"GB",
        //"country":"United Kingdom",
        //"contained_within":
        //"bounding_box":{
        //       "type":"Polygon",
        //       "coordinates":[
        //          [
        //             [
        //                -1.896927,
        //                53.609424
        //             ],
        //             [
        //                -1.726589,
        //                53.609424
        //             ],
        //             [
        //                -1.726589,
        //                53.685361
        //             ],
        //             [
        //                -1.896927,
        //                53.685361
        //             ]
        //          ]
        //       ]
        //    },
        //    "attributes":{

        //    }
        // },

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("place_type")]
        public string PlaceType { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("contained_within")]
        public object ContainedWithin { get; set; }

        [JsonProperty("bounding_box")]
        public object BoundingBox { get; set; }

    }

    public class BoundingBox
    {
        // "type":"Polygon",
        //       "coordinates":[
        //          [
        //             [
        //                -1.896927,
        //                53.609424
        //             ],
        //             [
        //                -1.726589,
        //                53.609424
        //             ],
        //             [
        //                -1.726589,
        //                53.685361
        //             ],
        //             [
        //                -1.896927,
        //                53.685361
        //             ]
        //          ]
        //       ]
        //    },
        //    "attributes":{
        //    }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("coordinates")]
        public JArray Coordinates { get; set; }
    }

}
