using Newtonsoft.Json;

namespace ErathQuakeTest.Models
{
    public class Feature
    {
        [JsonProperty("properties")]
        public Properties Properties { get; set; }

    }

}
