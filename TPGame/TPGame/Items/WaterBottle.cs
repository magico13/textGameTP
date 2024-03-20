using System;
using System.Collections.Generic;
using System.Text;
using TPGame.Handlers;
using TPGame.Models;
using TPGame.Models;

namespace TPGame.Items
{
    public class WaterBottle : Item
    {
        public WaterBottle()
        {
            Name = "Water Bottle";
            Description = "A tall, thin, green water bottle you stored for an emergency like this." + WaterStatus;
            Location = "Dining Room";
        }

        private bool HasWater = false;
        private string WaterStatus = "The bottle is currently empty. There has to be water around here somewhere...";
        private int Fills = 0;


        public InputAction Use(InputAction action, string roomName)
        {
            if (roomName == "Bathroom" && !HasWater)
            {
                HasWater = true;
                DialogueHandler.PrintLine("As you turn the knobs on the sink and the shower, a puff of dust shoots out. The pipes rattle violently but no water springs forth." +
                    "The only water seems to be that filling the bowl. You quickly assess when you last cleaned it and decide that this is an emergency." +
                    "You fill the bottle with as much water as you can and strap it back to your belt.");
                WaterStatus = "The bottle has been filled (best you can manage). It should be enough for one big drink.";
                Fills += 1;
            }
            else if (roomName == "Kitchen" && !HasWater)
            {
                HasWater = true;
                DialogueHandler.PrintLine("The fridge is empty. The icemaker shudders and spits out crumbs of ice. The sink roars and rattles but yields no water." +
                    "As you scan the kitchen, you spy a small bowl with \"Domino\" across the front. The pet dish glistens with fresh water." +
                    "You don't have any pets which gives you pause but that seems like an issue for another time." +
                    "You fill the bottle with as much water as you can and strap it back to your belt.");
                WaterStatus = "The bottle has been filled (best you can manage). It should be enough for one big drink.";
                Fills += 1;
            }
            if (HasWater)
            {
                bool drink = UserInput.GetBool("Your bottle has enough for one drink. Do you want to chug your water?");
                if (drink)
                {
                    HasWater = true;
                    DialogueHandler.PrintLine("Your hands shake from the sugar as you press the bottle to your lips. With a heave, you throw back your head as the water rushes down your throat." +
                        "You feel the water absorbing the sugar and easing your shakes. You're not sure if that's how it works, but this has been a slightly unorthodox day already.");
                    if (Fills < 2)
                    {
                        DialogueHandler.PrintLine("You drain the bottle before you know it and strap it back to your tool belt.");
                    }
                    else
                    {
                        DialogueHandler.PrintLine("You guzzle the water voraciously. So voraciously, that you crumple your water bottle. Thanks for your help, old friend, but this is where your journey ends." +
                            "You discard the bottle and press on.");
                        UsedUp = true;
                    }
                    WaterStatus = "You flip the bottle but get only a few drops.";
                    action.Command = "heal";
                }
            }
            return action;
        }
    }
}
