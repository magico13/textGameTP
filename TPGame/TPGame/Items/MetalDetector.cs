using TPGame.Dictionaries;
using TPGame.Handlers;
using TPGame.Rooms;
using TPGame.Models;

namespace TPGame.Items
{
    public class MetalDetector : Item
    {
        public MetalDetector() 
        {
            Name = "metal detector";
            Description = "A relatively small, relatively weak metal detector that should be plenty to find what you might need.";
        }

        public override void UseItem()
        {
            ((Backyard)(Collections.Rooms.Find(r => r.Name == "backyard"))).Interactables.Add("lever");
            DialogueHandler.PrintLine("MESSAGE NEEDED");
        }
    }
}
