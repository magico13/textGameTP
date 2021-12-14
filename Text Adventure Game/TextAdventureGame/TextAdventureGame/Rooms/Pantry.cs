using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureGame.MapLocations
{
    public class Pantry : Room 
    {
        public Pantry() : base()
        {
            Name = "Pantry";
            EncounterChance = 0.9;
            Description = "As you open the doors to the pantry, you hear rustling all over. There are almost certainly lolipops here.";
            Image = @"
 ||--------------------------------------||                                
 ||         |               |            ||                                     
 ||         |               |            ||                                     
 ||         |               |   ___      ||                                     
 ||         |               |   \_/      ||                                     
 ||--------------------------------------||                                     
 ||         __      |    --------------  ||                                     
 ||        |  |     |    |\    /\    /|  ||                                     
 ||     ___|__|__   |    | \  /  \  / |  ||                                     
 ||    |###| |###|  |    |  \/    \/  |  ||                                     
 ||    |___| |___|  |    |____________|  ||                                    
 ||--------------------------------------||                                     
 ||                                      ||                                     
 ||                                      ||                                     
 ||                                      ||                                     
 ||                                      ||       
 ||______________________________________||";
        }
    }
}
