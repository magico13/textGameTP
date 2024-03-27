using TPGame.Models;

namespace TPGame.Rooms
{
    public class Bathroom : Room
    {
        public Bathroom() : base()
        {
            Name = "Bathroom";
            EncounterChance = 0.25;
            Description = "You enter the bathroom, looking to take a break from your lolipop fighting.\nSurely, there wouldn't be any lolipops here...";
            GetItems = ["dentures"];
            Interactables = ["light switch", "sink", "bathtub", "towel", "medicine cabinet", "toilet"];
            Image = @" 
            __________                    
            |________|,                 
            |        |   /              
            |        |  /              
            |        / /               
            |       / /__________       
            |      /__|_________|_      
             \                   /      
              \                 /       
               |               /        
               |              /         
               |              |         
               |______________|";
        }
    }
}
