using System;
using System.Collections.Generic;
using TextAdventureGame.Handlers;
using TextAdventureGame.Models;
using TextAdventureGame.Items;

namespace TextAdventureGame.Commands
{
    public class InventoryCommand
    {
        public Dictionary<string, Item> Inventory = new Dictionary<string, Item>();

        public Dictionary<string, Item> AllItems = new()
        {
            ["buried switch"] = new BuriedSwitch(),
            ["camping lantern"] = new CampingLantern(),
            ["tool belt"] = new ToolBelt(),
            ["computer"] = new Computer(),
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

        public bool UseItem(Item item, string roomName)
        {
            if (item != null && roomName != "")
            {
                item.Use(Inventory, roomName);
            }
            else if (item != null)
            {
                return false;
            }
            return true;
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

        public Item VerifyItem(string itemName)
        {
            if (AllItems.TryGetValue(itemName, out Item item)) 
            { 
                return item;
            }
            return null;
        }

        public void AddItem(Item item)
        {
            if (Inventory.TryGetValue(item.Name, out Item value))
            {
                DialogueHandler.PrintLine($"You already have a {item.Name}");
            }
            else
            {
                Inventory[item.Name] = item;
            }
        }

        public void CheckItem(string target)
        {
            Item item = VerifyItem(target);
            if (item == null)
            {
                DialogueHandler.PrintLine($"You don't have a {target}");
            }
            else
            {
                DialogueHandler.PrintLine(item.Description);
            }
        }


        public void UseItem(InputAction action, string roomName)
        {
            if (action.Target == null)
            {
                action.Target = UserInput.GetString("What item do you want to use?");
            }
            Item item = VerifyItem(action.Target);
            if (item == null)
            {
                DialogueHandler.PrintLine($"You don't have a {action.Target}");
            }
            else
            {
                if (action != null && action.Command == "reject")
                {
                    DialogueHandler.PrintLine($"You can't use the {item.Name.ToLower()} here");
                }
                Console.WriteLine();
            }
        }

        public void GetItem(string target, string roomName)
        {
            if (target == null)
            {
                target = UserInput.GetString("What item do you want to use?");
            }
            Item item = VerifyItem(target);
            if (item == null || item.Location != roomName)
            {
                DialogueHandler.PrintLine($"The {roomName.ToLower()} doesn't have a {target.ToLower()}");
                Console.WriteLine();
            }
            else
            {
                AddItem(item);
                if (item.Name == "Tool Belt")
                {
                    DialogueHandler.PrintLine("You strap your tool belt around your waist and adjust the size to acccount for your recent weight loss.\nYou look great.\nYou feel great.");
                }
                else 
                { 
                    DialogueHandler.PrintLine($"You strap the {item.Name.ToLower()} to your tool belt.");
                }
                Console.WriteLine();
            }
        }
    }
}
