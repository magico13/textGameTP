using TPGame.Models;

namespace TPGame.Rooms
{
    public class Kitchen : Room
    {
        public Kitchen() : base()
        {
            Name = "Kitchen";
            EncounterChance = 0.8;
            Description = "The kitchen seems disturbingly still.\nEverything seems to be neatly in its place.";
            GetItems = ["knife"];
            Interactables = ["light switch", "sink", "cabinet", "fridge", "dog bowl"];
            Image = @"
                                         /------------\                                           
                                        /**************\                                          
                                        |**/--------\***|                                         
                                        |**|        |***|                                        
                                        |**|        |***|                                        
                                        |**|                                                       
                                        |**|                                                       
                                        |**|                                                       
                              (____     |**|     ____)                                             
                                 ||     |**|     ||                                                
                                 ||     |**|     ||                                             
           ____________________________________________________________                          
            \%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%/                           
            |########################################################|                           
            |########################################################|                           
            |________________________________________________________|
";
        }
    }
}
