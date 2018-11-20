using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
class State
{
   public bool on;
   public uint bri;
   public UInt16 hue;
   public uint sat;
   public string effect;
   public bool reachable;

    
}

namespace Philips_Hue_Control_Panel
{
    class SmartLight
    {
        public State state;
        string productname;
        //private System.Net.IPAddress IPAddress;
       
      
        

    }
}
