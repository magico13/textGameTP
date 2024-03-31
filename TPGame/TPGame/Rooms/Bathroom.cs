using TPGame.Models;

namespace TPGame.Rooms
{
    public class Bathroom : Room
    {
        public Bathroom() : base()
        {
            Name = "Bathroom";
            EncounterChance = 0.2;
            Description = "You enter the bathroom, looking to take a break from your lolipop fighting. The modestly sized room fits a SINK with a mirrored MEDICINE CABINET above it, a BATHTUB with your favorite TOWEL hanging on a nearby towel rack, and a porcelain white TOILET.";
            GetItems = ["dentures"];
            Interactables = ["light switch", "bathroom sink", "bathtub", "towel", "medicine cabinet", "toilet"];
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
