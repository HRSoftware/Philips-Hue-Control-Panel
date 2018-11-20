using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace Philips_Hue_Control_Panel

{
    class Hub
    {
        
        public System.Net.IPAddress ipAddress = System.Net.IPAddress.Parse("192.168.1.77");
        private string username;
       
        private List<SmartLight> allLights = new List<SmartLight>();

        public List<SmartLight> getAllLights()
        {
            return allLights;
        }
        
        public List<SmartLight> initListOfLights()
        {
            List<SmartLight> tempArray = new List<SmartLight>();
            var result = new WebClient().DownloadString("http://" + ipAddress + "/" + username + "/lights");

            dynamic dynJSON = JsonConvert.DeserializeObject<State>(result);

            foreach(var item in dynJSON)
            {
                SmartLight tempSmartLight = new SmartLight();
                
                tempSmartLight.state.on = item.state.on;
                tempSmartLight.state.bri = item.state.bri;
                tempSmartLight.state.hue = item.state.hue;
                tempSmartLight.state.sat = item.state.sat;
                tempSmartLight.state.effect = item.state.effect;
                tempSmartLight.state.reachable = item.state.reachable;

                tempArray.Add(tempSmartLight);

            }
            return tempArray;
        }

    }
}
