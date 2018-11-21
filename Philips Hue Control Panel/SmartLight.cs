using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
        public SmartLight(string _baseURL)
        {
            baseURL = _baseURL;
        }

        [JsonProperty(PropertyName = "state")]
        public State lightState { get; set; }

        public int lightID;
        private string baseURL
        {
            get; set;
        }

        //string productname;
        //private System.Net.IPAddress IPAddress;

        public string turnOn()
        {
            var request = (HttpWebRequest)WebRequest.Create(baseURL + lightID + "/state/");
            request.ContentType = "application/json";
            request.Method = "PUT";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {

                string json = "{\"on\":true}";
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();

            }

            var httpResponse = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                return streamReader.ReadToEnd();
            }
        }

        public string turnOff()
        {
            var request = (HttpWebRequest)WebRequest.Create(baseURL + lightID + "/state/");
            request.ContentType = "application/json";
            request.Method = "PUT";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {

                string json = "{\"on\":false}";
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();

            }

            var httpResponse = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                return streamReader.ReadToEnd();
            }
        }


    }
}
