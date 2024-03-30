using TPGame.Models;

namespace TPGame.Interactables
{
    public class Bathtub : Interactable
    {
        public Bathtub()
        {
            Name = "bathtub";
            Description = "A large, white bathtub. Your shower liner is getting near needing replaced and your shampoo is a little low.";
        }

        public override void UseInteractable()
        {
            base.UseInteractable("You can't seem to get any water from it. There doesn't seem to be anything else that would help you right now.");
        }
    }
}
