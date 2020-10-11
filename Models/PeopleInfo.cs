using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AglTest.Models
{
    public class PeopleInfo
    {

        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("gender")]
        public string gender { get; set; }
        [JsonProperty("age")]
        public string age { get; set; }
        [JsonProperty("pets")]
        public List<Pets> pets { get; set; }
    }

   

    public class Pets
    {
        [JsonProperty("type")]
        public string type { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }

    }
}
