using TPGame.Handlers;
using TPGame.Models;

namespace TPGame.Interactables
{
    public class Fridge : Interactable
    {
        public Fridge() 
        {
            Name = "fridge";
            Description = "A large metallic fridge/freezer combo. The power to the fridge seems to be off. You should investigate this later, but it would be better to leave it alone until the power returns.";
        }

        public override void UseInteractable()
        {
            DialogueHandler.PrintLine("Until you can figure out why the fridge has no power, it's better to leave it shut.");
        }
    }
}
