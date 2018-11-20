using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    class Room
    {

        private  SmartLight[] lights;
        public RoomType Name;

    }
}
