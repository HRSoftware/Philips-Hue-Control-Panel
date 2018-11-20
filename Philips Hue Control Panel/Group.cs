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

namespace Philips_Hue_Control_Panel
{
    class Group
    {

        public string Name;
      
        public GroupType enumGroupType;

        public SmartLight[] smartLights;

        
    }
}
