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

        public override void GetItem()
        {
            Basement basement = (Basement)Collections.Rooms.Find(r => r.Name == "Basement");
            basement.Description = basement.Description.Split("\n")[0];
            base.GetItem("You slip the metal detector over your back and through the strap tying it to your back.");
        }

        public override void UseItem()
        {
            string message;
            if (!((Backyard)(Collections.Rooms.Find(r => r.Name == "Backyard"))).UsableItems.Contains("shovel"))
            {
                ((Backyard)(Collections.Rooms.Find(r => r.Name == "Backyard"))).UsableItems.Add("shovel");
                DialogueHandler.PrintLine("You scan pile after pile, in search of something you hope is there. Your resolve weakens as you wonder if there is anything to find. What are the odds of it being metal?\n*BEEP BEEP*");
                DialogueHandler.AddPause(300);
                message = "Very good, apparently. You note the spot.";
                Collections.RemoveUsedItem(Name);
            }
            else
            {
                message = "You pat the metal detector for a job well done.";
            }
            base.UseItem(message);
        }
    }
}
