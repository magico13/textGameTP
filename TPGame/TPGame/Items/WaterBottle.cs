using TPGame.Characters;
using TPGame.Handlers;
using TPGame.Models;

namespace TPGame.Items
{
    public class WaterBottle : Item
    {
        public WaterBottle()
        {
            Name = "water bottle";
            Description = "A tall, thin, green water bottle you stored for an emergency like this. " +
                (WaterLevel > 0 ? $"You estimate that it has enough water to reduce your sugar level by about {WaterLevel}%" : "The bottle is empty. You should see if there's any water around.");
        }

        public static int WaterLevel = 0;

        public override void UseItem()
        {
            if (WaterLevel > 0)
            {
                if (Player.SugarLevel > 0)
                {
                    while (Player.SugarLevel > 0 && WaterLevel > 0)
                    {
                        Player.SugarLevel--;
                        WaterLevel--;
                    }
                    DialogueHandler.PrintLine("Your hands shake from the sugar as you press the bottle to your lips. With a heave, you throw back your head as the water rushes down your throat." +
                        "You feel the water absorbing the sugar and easing your shakes. You're not sure if that's how it works, but this has been a slightly unorthodox day already.");
                    DialogueHandler.PrintLine((Player.SugarLevel > 0 ? $"Your sugar level is now {Player.SugarLevel}%." : "You're now feeling sugar-free."));
                    DialogueHandler.PrintLine((WaterLevel > 0 ? $"Your the bottle still has some water left, about {WaterLevel}%." : "The bottle is now empty."));
                }
                else
                {
                    DialogueHandler.PrintLine("Hydration is important but you don't need to reduce your sugar level, a real and scientific biological metric, so you decide to wait on chugging your dubiously obtained water.");
                }
            }
            else
            {
                DialogueHandler.PrintLine("The bottle is empty. No matter how hard you try, you can't get so much as a drop.");
            }
        }
    }
}
