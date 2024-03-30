using TPGame.Models;

namespace TPGame.Rooms
{
    public class Backyard : Room
    {
        public Backyard() : base()
        {
            Name = "Backyard";
            EncounterChance = 0.1;
            Description = "You step outside for just a moment. The air is temperate and comfortable. Fresh air fills your lungs and reinvigorates you. Underneath it's cover rests your LAWNMOWER, a gift from your grandfather.\n" +
                "You see many mounds of dirt from where your yard has been dug up. You didn't dig any of these holes and you're not excited about needing to resod the lawn.";
            UsableItems = ["metal detector"];
            Interactables = ["lawn mower"];
            Image = @"
          /      /      /      /      /      /      /      /      /      /      /         
         |||    |||    |||    |||    |||    |||    |||    |||    |||    |||    |||       
        |||||  |||||  |||||  |||||  |||||  |||||  |||||  |||||  |||||  |||||  |||||       
     ,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,     
     ////////////////////////////////////////////////////////////////////////////////     
        |||||  |||||  |||||  |||||  |||||  |||||  |||||  |||||  |||||  |||||  |||||       
        |||||  |||||  |||||  |||||  |||||  |||||  |||||  |||||  |||||  |||||  |||||       
        |||||  |||||  |||||  |||||  |||||  |||||  |||||  |||||  |||||  |||||  |||||       
        |||||  |||||  |||||  |||||  |||||  |||||  |||||  |||||  |||||  |||||  |||||       
      ********************************************************************************    
     #################################################################################";
        }
    }
}
