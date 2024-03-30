using TPGame.Dictionaries;
using TPGame.Models;

namespace TPGame.Interactables
{
    public class Closet : Interactable
    {
        public Closet()
        {
            Name = "closet";
            Description = "A modest sized closet where you hang your work clothes and fashionable outfits.";
        }

        public override void UseInteractable()
        {
            string message = "You open the doors to see your nicer shirts and formal wear hanging neatly in a row.";
            if (!Collections.VerifyInventory("tool belt"))
            {
                message += " One of the hangers holds all of your belts, including your TOOL BELT.";
            }
            base.UseInteractable(message);
        }
    }
}
