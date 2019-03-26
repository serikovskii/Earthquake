using Newtonsoft.Json;

namespace ErathQuakeTest.Models
{
    public class Metadata
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }

}
