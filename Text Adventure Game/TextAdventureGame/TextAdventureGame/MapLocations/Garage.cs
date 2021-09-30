using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureGame.MapLocations
{
    public class Garage : Location
    {
        public Garage() : base()
        {
            Name = "Garage";
            EncounterChance = 0.45;
        }
    }
}
