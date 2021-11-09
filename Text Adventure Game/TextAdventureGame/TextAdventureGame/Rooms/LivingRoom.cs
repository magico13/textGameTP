using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureGame.MapLocations
{
    public class LivingRoom : Room 
    {
        public LivingRoom() : base()
        {
            Name = "Living Room";
            EncounterChance = 0.6;
            Description = "The sofa in your living room looks like lolipops have been jumping on it. The TV has been knocked off the entertainment stand.";
            Image = @"
                         ____
                        /    \
                       /______\
                          ||
           /~~~~~~~~~\    ||    /~~~~~~~~~~~~~~~~~\
          /~  () ()  ~\   ||   /~  ()  ()  () ()  ~\
         (_)=========(_)  ||  (_)=================(_)
          I|_________|I  _||_  |___________________|
.////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\";
        }
    }
}
