using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureGame.MapLocations
{
    public class Basement : Location
    {
        public Basement() : base()
        {
            Name = "Basement";
            EncounterChance = 0.0;
            Description = "You open the door to the basement and creep down the steps.\nThe basement is pitch black.\nYou can't see your own hands.\nThe light switch clicks uselessly." +
                "\n...\nYou need to find a light source to explore further.";
        }
    }
}
