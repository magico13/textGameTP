using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureGame.MapLocations
{
    public class Attic : Room
    {
        public Attic() : base()
        {
            Name = "Attic";
            EncounterChance = 0.5;
            Description = "You pull down the ladder to the attic.\nThe stairs creak beneath your feet as you climb.";
        }
    }
}
