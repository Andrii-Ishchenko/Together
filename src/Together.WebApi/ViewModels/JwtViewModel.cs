using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Together.WebApi.ViewModels
{
    public class JwtViewModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("auth_token")]
        public string Token { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }
}
