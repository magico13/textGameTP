using TPGame.Handlers;
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
            DialogueHandler.PrintLine("THIS NEEDS TO BE CHANGED");
        }
    }
}
