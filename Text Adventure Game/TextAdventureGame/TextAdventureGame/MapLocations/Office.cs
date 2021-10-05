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
            Description = "Small but cozy, you always feel at peace in your office.\nYour computer sits on a mahogany desk."; 
                //"\nThe old girl is just as reliable as the day you got her, which is to say not very."
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
