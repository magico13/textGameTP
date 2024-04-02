using TPGame.Dictionaries;
using TPGame.Handlers;
using TPGame.Items;
using TPGame.Models;

namespace TPGame.Interactables
{
    public class Toilet : Interactable
    {
        public Toilet() 
        {
            Name = "toilet";
            Description = "A small white toilet. You've been thinking about getting a bidet for it but haven't taken the plunge on yet." +
                (WaterLevel > 0 ? "\nThe bowl has some water in it." : "");
        }

        private int WaterLevel = 50;

        public override void UseInteractable()
        {
            string message;
            if (Collections.VerifyInventory("water bottle") && WaterLevel > 0)
            {
                ((WaterBottle)Collections.CheckInventory("water bottle")).AddWater(WaterLevel);
                WaterLevel = 0;
                DialogueHandler.PrintLine("You kneel down and inspect the bowl intensely. Desperate times...");
                DialogueHandler.AddPause(300);
                message = "You decide that you cleaned it recently enough and scoop up as much water as you can manage.";
            }
            else if (WaterLevel == 0)
            {
                DialogueHandler.PrintLine("The bowl doesn't have enough water in it...");
                DialogueHandler.AddPause(200);
                DialogueHandler.PrintLine("Unless you're willing to shove your head in and lick the drain...");
                DialogueHandler.AddPause(800);
                DialogueHandler.PrintLine("You're not are you?");
                DialogueHandler.AddPause(400);
                message = "You know what, I just decided you're not. Don't think about it anymore.";
            }
            else
            {
                message = "You lift the seat to see water in the bowl. Jiggling the handle doesn't seem to do anything. You check the tank to see that it is empty.";
            }
            base.UseInteractable(message);
        }
    }
}
