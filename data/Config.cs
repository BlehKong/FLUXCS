using Newtonsoft.Json;

namespace FLUX.data
{
    struct Config
    {
        [JsonProperty("prefix")]
        public string Prefix { get; private set; }

        [JsonProperty("token")]
        public string Token { get; private set; }
    }
}
