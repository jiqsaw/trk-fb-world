using Newtonsoft.Json;

namespace MvcHelper.Facebook.Models
{
    public class FacebookLocation
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

    }
}