using Newtonsoft.Json;

namespace FLUX.data
{
    struct JsonData
    {
        [JsonProperty("file")]
        public string Cat { get; private set; }
    }
}
