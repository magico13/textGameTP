using TPGame.Models;

namespace TPGame.Interactables
{
    public class LawnMower : Interactable
    {
        public LawnMower() 
        {
            Name = "lawnmower";
            Description = "An older push mower you got from your grandfather after he repaired it. It runs reliably but it doesn't have any gas right now. You could siphon from the car but then you wouldn't be able to go get more gas.";
        }

        public override void UseInteractable()
        {
            base.UseInteractable("You yank on the starter cord but can't seem to get the engine to do anything more than sputter.");
        }
    }
}
