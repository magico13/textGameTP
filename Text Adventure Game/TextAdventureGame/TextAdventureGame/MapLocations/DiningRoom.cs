using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureGame.MapLocations
{
    public class DiningRoom : Location
    {
        public DiningRoom() : base()
        {
            Name = "Dining Room";
            EncounterChance = 0.7;
        }
    }
}
