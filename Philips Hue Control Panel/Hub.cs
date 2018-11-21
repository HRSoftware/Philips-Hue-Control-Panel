using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Philips_Hue_Control_Panel

{
    class Hub
    {

        public Hub(string _baseURL)
        {
            baseURL = _baseURL;
           
            initListOfLights();
        }
        
        public string baseURL
        {
            get; set;
        }
        
       
        private Dictionary<int, SmartLight> allLights = new Dictionary<int, SmartLight>();

        public Dictionary<int, SmartLight> getAllLights()
        {
            if(allLights.Count == 0)
            {
               initListOfLights();
            }
            
            return allLights;
           
            
        }
        public SmartLight getSingleLight(int id)
        {
            return allLights[id];
        }
        
        public void initListOfLights()
        {

       




            string json = new WebClient().DownloadString(baseURL + "/lights/");
            var response = JsonConvert.DeserializeObject<Dictionary<int, SmartLight>>(json);
            foreach(var item in response)
            {
                SmartLight tempSmartLight = new SmartLight(baseURL + "/lights/");

                tempSmartLight.lightID = item.Key;
                tempSmartLight.lightState = item.Value.lightState;
               // tempSmartLight.lightState.bri = item.Value.lightState.bri;
               // tempSmartLight.lightState.on = item.Value.lightState.on;
                
               // tempSmartLight.lightState.hue = item.Value.lightState.hue;
               // tempSmartLight.lightState.sat = item.Value.lightState.sat;
               // tempSmartLight.lightState.effect = item.Value.lightState.effect;
               // tempSmartLight.lightState.reachable = item.Value.lightState.reachable;
               

                allLights[item.Key] = tempSmartLight; 

            }
            
        
            
        }

        public string TurnOnLight(int id)
        {
                return allLights[id].turnOn();
            
        }

        public string TurnOffLight(int id)
        {
            return allLights[id].turnOff();

        }
    }
}
