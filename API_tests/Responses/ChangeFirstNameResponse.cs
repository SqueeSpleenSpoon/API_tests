using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_tests.Responses
{
    class ChangeFirstNameResponse
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
    }
}
