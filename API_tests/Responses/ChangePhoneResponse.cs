using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_tests.Responses
{
    class ChangePhoneResponse
    {
        [JsonProperty("phone_number")]
        public string Phone { get; set; }
    }
}
