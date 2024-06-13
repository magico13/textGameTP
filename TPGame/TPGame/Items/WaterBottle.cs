using TPGame.Handlers;
using TPGame.Models;
using TPGame.Dictionaries;
using TPGame.Commands;

namespace TPGame.Items
{
    public class WaterBottle : Item
    {
        public WaterBottle()
        {
            Name = "water bottle";
            Description = "A tall, large, green water bottle you stored for an emergency like this.";
        }

        public int WaterLevel = 0;

        public void AddWater(int waterLevel)
        {
            WaterLevel += waterLevel;
        }

        public override void UseItem()
        {
            string message;
            if (WaterLevel > 0)
            {
                int sugar = InputHandler.Character.Player.GetSugar();
                if (sugar > 0)
                {
                    if (WaterLevel > sugar)
                    {
                        WaterLevel -= sugar;
                        sugar = 0;
                    }
                    else
                    {
                        sugar -= WaterLevel;
                        WaterLevel = 0;
                    }
                    InputHandler.Character.Player.SetSugar(sugar);
                    DialogueHandler.PrintLine("Your hands shake from the sugar as you press the bottle to your lips. With a heave, you throw back your head as the water rushes down your throat. " +
                        "You feel the water absorbing the sugar and easing your shakes. You're not sure if that's how it works, but this has been a slightly unorthodox day already.");
                    DialogueHandler.PrintLine(sugar > 0 ? $"Your sugar level is now {sugar}%." : "You're now feeling sugar-free.");
                    message = (WaterLevel > 0 ? $"The bottle still has some water left, about {WaterLevel}%." : "The bottle is now empty.");
                }
                else
                {
                    message = "Hydration is important but you don't need to reduce your sugar level, a real and scientific biological metric, so you decide to wait on chugging your dubiously obtained water.";
                }
            }
            else
            {
                message = "The bottle is empty. No matter how hard you try, you can't get so much as a drop.";
            }
            if (InputHandler.Map.CurrentLocation.Name == "Hidden Room" && WaterLevel > 0)
            {
                message = "Knowing this is your last chance to use it, you spray all of your remaining water over the king. The powerful spray wears down his thick outer shell. " + InputHandler.Character.AttackKing(WaterLevel);
                Collections.RemoveUsedItem(Name);
            }
            base.UseItem(message);
        }
    }
}
