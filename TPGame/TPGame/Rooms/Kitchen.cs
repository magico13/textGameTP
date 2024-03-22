using TPGame.Models;

namespace TPGame.MapLocations
{
    public class Kitchen : Room
    {
        public Kitchen() : base()
        {
            Name = "Kitchen";
            EncounterChance = 0.8;
            Description = "The kitchen seems disturbingly still.\nEverything seems to be neatly in its place.";
            GetItems = ["knife"];
            Interactables = ["sink", "cabinet", "fridge", "dog bowl"];
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
