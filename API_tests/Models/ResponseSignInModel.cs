using Newtonsoft.Json;

namespace API_tests.Models
{
    public class ResponseSignInModel
    {
        [JsonProperty("token_data")]
        public TokenData TokenData { get; set; }
    }
}