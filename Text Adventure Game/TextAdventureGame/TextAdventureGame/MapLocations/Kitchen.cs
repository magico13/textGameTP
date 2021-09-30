using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureGame.MapLocations
{
    public class Kitchen : Location
    {
        public Kitchen() : base()
        {
            Name = "Kitchen";
            EncounterChance = 0.8;
        }
    }
}
