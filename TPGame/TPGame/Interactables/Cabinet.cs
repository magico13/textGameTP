using TPGame.Dictionaries;
using TPGame.Models;

namespace TPGame.Interactables
{
    public class Cabinet : Interactable
    {
        public Cabinet() 
        {
            Name = "cabinet";
            Description = "The handleless doors of the cabinets look like they could use a cleaning, but you're overall proud of your kitchen.";
        }

        public override void UseInteractable()
        {
            string message = "You open the cabinet doors.";
            if (!Collections.VerifyInventory("water bottle"))
            {
                message += " On one shelf is a WATER BOTTLE that looks like it's been cleaned recently.";
            }
            else
            {
                message += " You see clean pots and pans. You start wondering what to make for dinner before your stomach rumbles. Maybe just a slice of bread to soak up some of the sugar.";
            }
            base.UseInteractable(message);
        }
    }
}
