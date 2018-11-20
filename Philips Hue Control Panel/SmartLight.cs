using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Philips_Hue_Control_Panel
{

    class State
    {
        [JsonProperty(PropertyName ="@on")]
        public bool on { get; set; }

        [JsonProperty(PropertyName = "bri")]
        public uint bri { get; set; }

        [JsonProperty(PropertyName = "hue")]
        public UInt16 hue { get; set; }

        [JsonProperty(PropertyName = "sat")]
        public uint sat { get; set; }

        [JsonProperty(PropertyName = "effect")]
        public string effect { get; set; }

        [JsonProperty(PropertyName = "reachable")]
        public bool reachable { get; set; }


    }
    class SmartLight
    {
        [JsonProperty(PropertyName = "state")]
        public State lightState { get; set; }


        //string productname;
        //private System.Net.IPAddress IPAddress;
       
      
        

    }
}
