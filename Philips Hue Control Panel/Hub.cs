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

        public Hub(string newIPAddress, string User)
        {
            ipAddress = IPAddress.Parse(newIPAddress);
            username = User;
            initListOfLights();

            
            
        }
        
        public IPAddress ipAddress;
        private string username;
       
        private List<SmartLight> allLights = new List<SmartLight>();

        public List<SmartLight> getAllLights()
        {
            if(allLights.Count == 0)
            {
               initListOfLights();
            }
            
            return allLights;
           
            
        }
        
        public async void initListOfLights()
        {

            string address = "http://"+ ipAddress + "/api/" + username + "/lights";




            string json = new WebClient().DownloadString(address);
            var response = JsonConvert.DeserializeObject<Dictionary<int, SmartLight>>(json);
            foreach(var item in response.Values)
            {
                SmartLight tempSmartLight = new SmartLight();

                tempSmartLight.lightState = item.lightState;
                tempSmartLight.lightState.bri = item.lightState.bri;
                tempSmartLight.lightState.on = item.lightState.on;
                
                tempSmartLight.lightState.hue = item.lightState.hue;
                tempSmartLight.lightState.sat = item.lightState.sat;
                tempSmartLight.lightState.effect = item.lightState.effect;
                tempSmartLight.lightState.reachable = item.lightState.reachable;

                allLights.Add(tempSmartLight);

            }
            
        
            
        }

    }
}
