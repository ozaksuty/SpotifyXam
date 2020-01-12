using Newtonsoft.Json;

namespace SpotifyXam.Models
{
    public class VideoThumbnail
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}