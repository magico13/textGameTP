using TPGame.Models;

namespace TPGame.Interactables
{
    public class Furnace : Interactable
    {
        public Furnace() 
        {
            Name = "furnace";
            Description = "A decently new furnace. You've never had any problems with it.";
        }

        public override void UseInteractable()
        {
            base.UseInteractable("You touch the furnace haphazardly. It's cool to the touch. The weather has been warm and sunny recently, so there's been no need to run the furnace.");
        }
    }
}
