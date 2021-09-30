using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureGame.MapLocations
{
    public class LivingRoom : Location 
    {
        public LivingRoom() : base()
        {
            Name = "Living Room";
            EncounterChance = 0.6;
        }
    }
}
