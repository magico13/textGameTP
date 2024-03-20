using System.Collections.Generic;
using TPGame.Handlers;
using TPGame.Items;
using TPGame.Models;

namespace TPGame.Commands
{
    public class InventoryCommand
    {
        public Dictionary<string, Item> Inventory = new Dictionary<string, Item>();

        public Dictionary<string, Item> AllItems = new()
        {
            ["batteries"] = new Batteries(),
            ["camping lantern"] = new CampingLantern(),
            ["tool belt"] = new ToolBelt(),
            ["key"] = new Key(),
            ["knife"] = new Knife(),
            ["metal detector"] = new MetalDetector(),
            ["shovel"] = new Shovel(),
            ["water bottle"] = new WaterBottle(),
        };

        /// <summary>
        /// Returns the description of an item
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>a
        public string CheckItem(Item target)
        {
            if (Inventory.TryGetValue(target.Name, out Item item))
            {
                return item.Description;
            }

            return $"You don't have a {target.Name.ToLower()}";
        }

        public void CheckInventory()
        {
            if (Inventory.Count > 0)
            {
                foreach (KeyValuePair<string, Item> item in Inventory)
                {
                    DialogueHandler.PrintLine(item.Value.Name);
                }
            }
            else
            {
                DialogueHandler.PrintLine("You don't have anything on you right now");
            }
        }

        public void CheckItem(string target)
        {
            target ??= UserInput.GetString("What item do you want to check?");
            if (AllItems.ContainsKey(target) && Inventory.TryGetValue(target, out Item item))
            {
                item.CheckItem();
            }
            else
            {
                DialogueHandler.PrintLine($"You don't have a {target}");
            }
        }


        public void UseItem(string target, string roomName)
        {
            target ??= UserInput.GetString("What item do you want to use?");
            if (AllItems.ContainsKey(target) && Inventory.TryGetValue(target, out Item item))
            {
                item.UseItem(roomName);
            }
            else
            {
                DialogueHandler.PrintLine($"You don't have a {target}");
            }
        }

        public void GetItem(string target, string roomName)
        {
            target ??= UserInput.GetString("What item do you want to take?");
            if (AllItems.TryGetValue(target, out Item item))
            {
                item.GetItem(roomName);

                if (!Inventory.TryAdd(item.Name, item))
                {
                    DialogueHandler.PrintLine($"You already have a {item.Name}");
                }
            }
            else
            {
                DialogueHandler.PrintLine($"The {roomName.ToLower()} doesn't have a {target.ToLower()}");
            }
        }
    }
}
