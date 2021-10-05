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
            Image = @"
      ()___ 
    ()//__/)_________________()
    ||(___)//#/_/#/_/#/_/#()/||
    ||----|#| |#|_|#|_|#|_|| ||
    ||____|_|#|_|#|_|#|_|#||/||
    ||    |#|_|#|_|#|_|#|_||";
        }
    }
}
