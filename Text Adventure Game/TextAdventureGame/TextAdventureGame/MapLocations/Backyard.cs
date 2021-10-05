using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureGame.MapLocations
{
    public class Backyard : Location
    {
        public Backyard() : base()
        {
            Name = "Backyard";
            EncounterChance = 0.1;
            Image = @"
  _   _   _   _   _   _   _   _   _   _
_| |_| |_| |_| |_| |_| |_| |_| |_| |_| |_
-| |-| |-| |-| |-| |-| |-| |-| |-| |-| |-
 | | | | | | | | | | | | | | | | | | | |
_| |_| |_| |_| |_| |_| |_| |_| |_| |_| |_
-| |-| |-| |-| |-| |-| |-| |-| |-| |-| |-
 |_| |_| |_| |_| |_| |_| |_|||_| |_| |_| 
,,,,,,||,,,,,,,,,,,,,,,,,,,,||,,,,,,,,,,,,,,,,";
        }
    }
}
