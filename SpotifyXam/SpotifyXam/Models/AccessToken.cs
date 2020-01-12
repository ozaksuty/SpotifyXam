using Newtonsoft.Json;
using System;

namespace SpotifyXam.Models
{
    public class AccessToken
    {
        [JsonProperty("access_token")]
        public string Token { get; set; }
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
        [JsonProperty("scope")]
        public string Scope { get; set; }
        public DateTime? Expires { get; set; }
    }
}