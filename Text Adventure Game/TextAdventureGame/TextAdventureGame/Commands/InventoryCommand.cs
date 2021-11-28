using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.Mechanics;
using TextAdventureGame.Models;
using TextAdventureGame.Items;

namespace TextAdventureGame.Commands
{
    public class InventoryCommand : IInventoryCommand
    {
        private readonly ItemManager ItemManager = new ItemManager();

        public InputAction Execute(InputAction action, string roomName)
        {
            switch (action.Command)
            {
                case "use":
                    UseItem(action, roomName);
                    return null;
                case "check":
                    CheckItem(action);
                    return null;
                case "get":
                    AddItemToInventory(action, roomName);
                    return null;
                default:
                    return null;
            }
        }

        private void CheckItem(InputAction action)
        {
            Item item = ItemManager.CheckForItem(action.Target);
            if (item == null)
            {
                Start.PrintLine($"You don't have a {action.Target}");
            }
            else
            {
                Start.PrintLine(ItemManager.CheckItem(item));
            }
        }


        private InputAction UseItem(InputAction action, string roomName)
        {
            Item item = CheckForTarget(action);
            if (item == null)
            {
                Start.PrintLine($"You don't have a {action.Target}");
                return null;
            }
            else
            {
                action = ItemManager.UseItem(item, roomName);
                if (action != null && action.Command == "reject")
                {
                    Start.PrintLine($"You can't use the {item.Name.ToLower()} here");
                    return null;
                }
                Console.WriteLine();
                return action;
            }
        }

        private void AddItemToInventory(InputAction action, string roomName)
        {
            Item item = CheckForTarget(action);
            if (item == null)
            {
                Start.PrintLine($"You don't have a {action.Target}");
                Console.WriteLine();
            }
            else if (item.Location != roomName)
            {
                Start.PrintLine($"There's nowhere to use the {item} in the {roomName}");
                Console.WriteLine();
            }
            else
            {
                ItemManager.AddItem(item);
                if (item.Name == "Tool Belt")
                {
                    Start.PrintLine("You strap your tool belt around waist and adjust the size to acccount for your recent weight loss.\nYou look great.          \nYou feel great.");
                }
                Start.PrintLine($"You strap the {item.Name} to your tool belt.");
                Console.WriteLine();
            }
        }

        private Item CheckForTarget(InputAction action)
        {
            if (action.Target == null)
            {
                action.Target = UserInput.GetString("What item do you want to use?");
            }
            return ItemManager.CheckForItem(action.Target);
        }
    }
}
