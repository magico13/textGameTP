using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureGame.MapLocations
{
    public class Pantry : Location 
    {
        public Pantry() : base()
        {
            Name = "Pantry";
            EncounterChance = 0.9;
        }
    }
}
