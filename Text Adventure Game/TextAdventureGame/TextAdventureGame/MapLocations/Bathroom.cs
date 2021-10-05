using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureGame.MapLocations
{
    public class Bathroom : Location
    {
        public Bathroom() : base()
        {
            Name = "Bathroom";
            EncounterChance = 0.25;
            Description = "You enter the bathroom, looking to take a break from your lolipop fighting.\nSurely, there wouldn't be any lolipops here...";
            Image = @" 
           .--'""""""""""`--. 
         ,'     .------.     `,
         :     (        )     :
         |\     `------'     /|
         | `--.__________,--' |
         |          /         |
         |          \         |
         |          /         |
         |          \         |
         |          /         |
         |          \         |
         |          /         |
         |          \         |
         |          /         |
         |          \         |
         `.         /        .'
           `--._____\____,--' ";
        }
    }
}
