using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureGame.MapLocations
{
    public class LivingRoom : Location 
    {
        public LivingRoom() : base()
        {
            Name = "Living Room";
            EncounterChance = 0.6;
            Image = @"
                         ____
                        /    \
                       /______\
                          ||
           /~~~~~~~~\     ||    /~~~~~~~~~~~~~~~~\
          /~ () ()  ~\    ||   /~ ()  ()  () ()  ~\
         (_)========(_)   ||  (_)==== ===========(_)
          I|_________|I  _||_  |___________________|
.////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\";
        }
    }
}
