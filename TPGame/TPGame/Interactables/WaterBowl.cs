using TPGame.Dictionaries;
using TPGame.Models;
using TPGame.Items;
using TPGame.Handlers;

namespace TPGame.Interactables
{
    public class WaterBowl : Interactable
    {
        public WaterBowl()
        {
            Name = "water bowl";
            Description = "A small bowl with \"Domino\" across the front. The pet dish glistens with fresh water. You don't have any pets which gives you pause but that seems like an issue for another time.";
        }

        private int WaterLevel = 100;

        public override void UseInteractable()
        {
            string message;
            if (Collections.VerifyInventory("water bottle") && WaterLevel > 0)
            {
                WaterBottle.AddWater(WaterLevel);
                WaterLevel = 0;
                DialogueHandler.PrintLine("You kneel down and inspect the water briefly. Desperate times...");
                DialogueHandler.AddPause(300);
                message = "You gently pour as much of the water as you can into your water bottle";
            }
            else
            {
                message = "The bowl seems to be in pristine condition. Where did it come from? How did it get filled with water? You move on without thinking too hard about it.";
            }
            base.UseInteractable(message);
        }
    }
}
