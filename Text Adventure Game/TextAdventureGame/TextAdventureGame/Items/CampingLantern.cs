using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.MapLocations;

namespace TextAdventureGame.Items
{
    public class CampingLantern : Item
    {
        public CampingLantern()
        {
            Name = "Camping Lantern";
            Description = "\"For Use In Emergencies\" feels very appropriate right now. The lantern requires 4 'C' batteries, which are not included currently.";
            Location = "Attic";
        }
    }
}

