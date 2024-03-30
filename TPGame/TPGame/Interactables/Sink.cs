using TPGame.Handlers;
using TPGame.Items;
using TPGame.Models;

namespace TPGame.Interactables
{
    public class Sink : Interactable
    {
        public Sink(string roomName)
        {
            Name = "sink";
            
            switch (roomName)
            {
                case "Bathroom":
                    Name = "bathroom sink";
                    Description = "A small sink with a mirror above it. Your toothbrush sits in a cup next to a mostly empty tube of toothpaste.";
                    break;
                case "Kitchen":
                    Name = "kitchen sink";
                    Description = "A single-chambered metal sink that is currently empty. You cleaned all of your dishes the night before.";
                    break;
                default:
                    Name = "sink";
                    Description = "A sink.";
                    break;
            }
        }

        public int WaterLevel = 0;

        public override void UseInteractable()
        {
            string message;
            if (WaterLevel > 0)
            {
                WaterBottle.AddWater(WaterLevel);
                WaterLevel = 0;
                message = "You're able to get a little bit of water out of the sink.";
            }
            else
            {
                message = "No matter how hard you try, you can't get any water out of the sink.";
            }
            base.UseInteractable(message);
        }
    }
}
