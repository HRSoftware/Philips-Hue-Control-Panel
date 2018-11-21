using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


enum GroupType
{
   Luminaire,
   LightSource,
   LightGroup,
   Room,
   Entertainment
}

enum RoomType
{
    LivingRoom,
    Kitchen,
    Dining,
    Bedroom,
    KidsBedroom,
    Bathroom,
    Nursery,
    Recreation,
    Office,
    Gym,
    Hallway,
    Toilet,
    FrontDoor,
    Garage,
    Terrace,
    Garden,
    Driveway,
    Carport,
    Other
}



namespace Philips_Hue_Control_Panel
{
    class actionObject
    {
        [JsonProperty(propertyName: "any_on")]
        public bool anyOn;

        [JsonProperty(propertyName: "all_on")]
        public bool allOn;
    }
    class Group
    {

        public int ID;

        [JsonProperty(propertyName: "name")]
        public int Name;

        [JsonProperty(propertyName: "lights")]
        public int[] lights;

        [JsonProperty(propertyName: "sensors")]
        public int[] sensors;

        [JsonProperty(propertyName: "type")]
        public GroupType type;

        [JsonProperty(propertyName: "class")]
        public RoomType room;


        public SmartLight[] smartLights;

        
    }
}
