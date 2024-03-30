using TPGame.Models;

namespace TPGame.Rooms
{
    public class Pantry : Room 
    {
        public Pantry() : base()
        {
            Name = "Pantry";
            EncounterChance = 0.95;
            Description = "As you open the doors to the pantry, you hear rustling all over. There are almost certainly lolipops here. Of course, they're easy to find with a simple SEARCH.";
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
