using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureGame.MapLocations
{
    public class Office : Location
    {
        public Office() : base()
        {
            Name = "Office";
            EncounterChance = 0.4;
            Image = @"
              .........
            .'------.' |       
           | .-----. | |
           | |     | | |
         __| |     | | |;. _______________
        /  |*`-----'.|.' `;              //
       /   `---------' .;'              //
 /|   /  .''''////////;'               //
|=|  .../ ######### /;/               //|
|/  /  / ######### //                //||
   /   `-----------'                // ||
  /________________________________//| ||
  `--------------------------------' | ||
   : | ||      | || |__LL__|| ||     | ||
   : | ||      | ||         | ||     `""'
   n | ||      `""'         | ||
   M | ||                   | ||
     | ||                   | ||
     `""'                   `""'";
        }
    }
}
