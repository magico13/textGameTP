using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.Handlers;
using TextAdventureGame.Models;
using TextAdventureGame.Items;

namespace TextAdventureGame.Commands
{
    public class InventoryCommand
    {
        private readonly ItemManager ItemManager = new ItemManager();

        public void Execute(InputAction action, string roomName)
        {
            switch (action.Command)
            {
                case "use":
                    UseItem(action, roomName);
                    break;
                case "check":
                    CheckItem(action.Target);
                    break;
                default:
                    break;
            }
        }

        public void CheckItem(string target)
        {
            Item item = ItemManager.VerifyItem(target);
            if (item == null)
            {
                DialogueHandler.PrintLine($"You don't have a {target}");
            }
            else
            {
                DialogueHandler.PrintLine(ItemManager.CheckItem(item));
            }
        }


        public InputAction UseItem(InputAction action, string roomName)
        {
            if (action.Target == null)
            {
                action.Target = UserInput.GetString("What item do you want to use?");
            }
            Item item = ItemManager.VerifyItem(action.Target);
            if (item == null)
            {
                DialogueHandler.PrintLine($"You don't have a {action.Target}");
                return null;
            }
            else
            {
                ItemManager.UseItem(item, roomName);
                if (action != null && action.Command == "reject")
                {
                    DialogueHandler.PrintLine($"You can't use the {item.Name.ToLower()} here");
                    return null;
                }
                Console.WriteLine();
                return action;
            }
        }

        public void GetItem(string target, string roomName)
        {
            if (target == null)
            {
                target = UserInput.GetString("What item do you want to use?");
            }
            Item item = ItemManager.VerifyItem(target);
            if (item == null)
            {
                DialogueHandler.PrintLine($"The {roomName} doesn't have a {target}");
                Console.WriteLine();
            }
            else if (item.Location != roomName)
            {
                DialogueHandler.PrintLine($"There's nowhere to use the {item} in the {roomName}");
                Console.WriteLine();
            }
            else
            {
                ItemManager.AddItem(item);
                if (item.Name == "Tool Belt")
                {
                    DialogueHandler.PrintLine("You strap your tool belt around waist and adjust the size to acccount for your recent weight loss.\nYou look great.          \nYou feel great.");
                }
                DialogueHandler.PrintLine($"You strap the {item.Name} to your tool belt.");
                Console.WriteLine();
            }
        }
    }
}
