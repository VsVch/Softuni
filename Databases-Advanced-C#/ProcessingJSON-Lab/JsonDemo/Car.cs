using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace JsonDemo
{
    public class Car
    {
        public string Model { get; set; }
        
        public string Vendor { get; set; }

        public decimal Price { get; set; }

        public DateTime ManufacturedOn { get; set; }
        [JsonIgnore]
        public List<string> Extras { get; set; }
        [JsonIgnore]
        public Engine Engine { get; set; }
    }
}
