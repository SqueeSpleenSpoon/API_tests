using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_tests.Responses
{
    class ChangeLastNameResponse
    {
        [JsonProperty("last_name")]
        public string LastName { get; set; }
    }
}
