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
            EncounterChance = 0.25;
        }
    }
}
