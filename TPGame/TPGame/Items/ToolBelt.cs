using System.Collections.Generic;
using TPGame.Dictionaries;
using TPGame.Handlers;
using TPGame.Models;

namespace TPGame.Items
{
    public class ToolBelt : Item
    {
        public ToolBelt()
        {
            Name = "tool belt";
            Description = "A modified utilty belt prepared to hold any items you find that seem useful, no matter how impratically sized.";
            Uses = 999;
            UsedDescription = Description;
        }

        public override void GetItem()
        {
            DialogueHandler.PrintLine("You strap your tool belt around your waist and adjust the size to acccount for your recent weight loss.");
            DialogueHandler.AddPause();
            DialogueHandler.PrintLine("You look great.");
            DialogueHandler.AddPause();
            DialogueHandler.PrintLine("You feel great.");
        }

        public override void UseItem()
        {
            DialogueHandler.PrintLine("You look at your belt to see what all you've collected.");

            if (Collections.Inventory.Count > 0)
            {
                foreach (KeyValuePair<string, Item> item in Collections.Inventory)
                {
                    if (item.Key != "tool belt" && item.Value.Uses > 0) 
                    { 
                        DialogueHandler.PrintLine($"{item.Key}");
                    }
                }
            }
            else
            {
                DialogueHandler.PrintLine("Just a bunch of empty pockets, holsters, and straps.");
            }
        }
    }
}
