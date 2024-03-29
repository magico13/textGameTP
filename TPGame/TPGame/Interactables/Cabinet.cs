using TPGame.Handlers;
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
            DialogueHandler.PrintLine("You open the cabinet doors. On one shelf is a WATER BOTTLE that looks like it's been cleaned recently.");
        }
    }
}
