using Newtonsoft.Json;
using System;

namespace StarterTemplate.APIs.ChuckNorrisIO
{
    public class JokeResponseModel
    {
        [JsonProperty("category")]
        public object Category { get; set; }

        [JsonProperty("icon_url")]
        public Uri IconUrl { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
