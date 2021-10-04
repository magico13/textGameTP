using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureGame.MapLocations
{
    public class GuestBedroom : Location
    {
        public GuestBedroom() : base()
        {
            Name = "Guest Bedroom";
            EncounterChance = 0.45;
        }
    }
}
