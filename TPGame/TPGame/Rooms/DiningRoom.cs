using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureGame.MapLocations
{
    public class DiningRoom : Room
    {
        public DiningRoom() : base()
        {
            Name = "Dining Room";
            EncounterChance = 0.7;
            Description = "The dining room is ornately decorated.\nThe table is set with lit candles and empty dishes.";
            Image = @"
   \\                             /           /       /                               //  
    \\                            #           #       #                              //   
     \\  _________________________#___________#_______#__________________________  //    
      \\______________               |               |               ______________//     
       _______________)             /                 \             (_______________      
        ||          ||             /                   \             ||          ||       
        ||          ||             |                   |             ||          ||
        ||          ||             |                   |             ||          ||
        ||          ||              \                 /              ||          ||
        ||          ||                ________________               ||          ||";
        }
    }
}
