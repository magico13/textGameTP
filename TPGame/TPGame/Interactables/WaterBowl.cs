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

        private int WaterLevel = 60;

        public override void UseInteractable()
        {
            if (Collections.Inventory.Find(item => item.Name == "water bottle") != null && WaterLevel > 0)
            {
                WaterBottle.WaterLevel += WaterLevel;
                WaterLevel = 0;
                DialogueHandler.PrintLine("You kneel down and inspect the water briefly. Desperate times...");
                DialogueHandler.AddPause(300);
                DialogueHandler.PrintLine("You gently pour as much of the water as you can into your water bottle");
            }
            else
            {
                DialogueHandler.PrintLine("The bowl seems to be in pristine condition. Where did it come from? How did it get filled with water? You move on without thinking too hard about it.");
            }
        }
    }
}
