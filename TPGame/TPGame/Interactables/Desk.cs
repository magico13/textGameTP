using TPGame.Dictionaries;
using TPGame.Models;

namespace TPGame.Interactables
{
    public class Desk : Interactable
    {
        public Desk()
        {
            Name = "desk";
            Description = "A white wooden desk where you do all of your vaguely defined work.";
        }

        public override void UseInteractable()
        {
            string message;
            if (!Collections.VerifyInventory("batteries"))
            {
                message = "You pull out the drawer and see 4 BATTERIES. They're size C.";
            }
            else
            {
                message = "You can't find anything else of use and would rather not get back to work on your project just yet.";
            }
            base.UseInteractable(message);
        }
    }
}
