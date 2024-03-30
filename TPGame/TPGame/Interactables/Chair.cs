using TPGame.Models;

namespace TPGame.Interactables
{
    public class Chair : Interactable
    {
        public Chair()
        {
            Name = "chair";
            Description = "An affordable wooden chair with a cushioned seat. Well-maintained and recently reupholstered, you're very proud of your dining room chairs.";
        }

        public override void UseInteractable()
        {
            base.UseInteractable("You consider standing on the chairs but decide against it. The cushions are in great shape, and you don't want to risk falling and ending the game prematurely.");
        }
    }
}
