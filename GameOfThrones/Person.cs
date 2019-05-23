using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfThrones
{
    public class Person
    {
        public List<string> Titles { get; set; }
        public List<string> Origin { get; set; }
        public List<string> Siblings { get; set; }
        public List<string> Spouse { get; set; }
        public List<string> Lovers { get; set; }
        public List<string> Culture { get; set; }
        public List<string> Religion { get; set; }
        public List<string> Allegiances { get; set; }
        public List<string> Seasons { get; set; }
        public List<string> Appearances { get; set; }
        [JsonProperty("_id")]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Image { get; set; }
        public string Gender { get; set; }
        public bool Alive { get; set; }
        public int Death { get; set; }
        public string Father { get; set; }
        public string House { get; set; }
        [JsonProperty("first_seen")]
        public string FirstSeen { get; set; }
        public string Actor { get; set; }
        public string Mother { get; set; }
        public int? Birth { get; set; }
    }
}
