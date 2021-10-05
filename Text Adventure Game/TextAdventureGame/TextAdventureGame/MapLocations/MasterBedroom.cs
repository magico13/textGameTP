using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureGame.MapLocations
{
    public class MasterBedroom : Location
    {
        public MasterBedroom() : base()
        {
            Name = "Master Bedroom";
            EncounterChance = 0.6;
            Image = @"
         ()___ 
         //  /)_______________()
        //__//#/_/#/_/#/_/#/_/||
    () //  /)/_/#/_/#/_/#/_/# ||
    ||//__/)/_/#/_/#/_/#/_/# /||
    ||(___)//#/_/#/_/#/_/#()/ ||
    ||----|#| |#|_|#|_|#|_|| /
    ||____|_|#|_|#|_|#|_|#||/ 
    ||    |#|_|#|_|#|_|#|_|| ";
        }
    }
}
