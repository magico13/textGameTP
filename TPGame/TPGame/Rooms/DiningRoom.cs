using TPGame.Models;

namespace TPGame.MapLocations
{
    public class DiningRoom : Room
    {
        public DiningRoom() : base()
        {
            Name = "Dining Room";
            EncounterChance = 0.7;
            Description = "The dining room is ornately decorated.\nThe table is set with lit candles and empty dishes.";
            Interactables = ["light switch", "candles", "chairs", "table"];
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
