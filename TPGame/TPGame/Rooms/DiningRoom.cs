using TPGame.Models;

namespace TPGame.Rooms
{
    public class DiningRoom : Room
    {
        public DiningRoom() : base()
        {
            Name = "Dining Room";
            EncounterChance = 0.7;
            Description = "The dining room is ornately decorated. The TABLE is set with silver candle holders with long white CANDLES and empty dishes. The CHAIRs are all pushed in curteously.";
            Interactables = ["light switch", "candles", "chair", "table"];
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
