using TPGame.Dictionaries;
using TPGame.Handlers;
using TPGame.Models;
using TPGame.Items;

namespace TPGame.Interactables
{
    public class Computer : Interactable
    {
        public Computer()
        {
            Name = "computer";
            Description = "The old girl is just as reliable as the day you got her, which is to say not very.";
        }

        public override void UseInteractable()
        {
            if (!Collections.VerifyInventory("hints"))
            {
                DialogueHandler.PrintLine("You dig through your folders to find your emergency plan. With that printed out, you'll be able to reference your plan whenever you forget it.");
                Collections.Inventory.Add(new HintList());
            }
            else 
            {
                DialogueHandler.PrintLine("You spot a folder of unfinished projects that were started and abandoned. You don't have the time right now. Just definitely don't forget to work on them when things calm down...");
            }
        }
    }
}

