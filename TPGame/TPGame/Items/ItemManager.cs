using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.Handlers;
using TextAdventureGame.Models;

namespace TextAdventureGame.Items
{
    public class ItemManager
    {
        public ItemManager() { }

        public Dictionary<string, Item> Inventory = new Dictionary<string, Item>();

        public Dictionary<string, Item> AllItems = new Dictionary<string, Item>()
        {
            ["buried switch"] = new BuriedSwitch(),
            ["camping lantern"] = new CampingLantern(),
            ["cheats"] = new Cheats(),
            ["computer"] = new Computer(),
            ["garage key"] = new GarageKey(),
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
        public string CheckItem(Item item)
        {
            if (Inventory.ContainsKey(item.Name))
            {
                return Inventory[item.Name].Description;
            }

            return $"You don't have a {item.Name.ToLower()}";
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

        public Item VerifyItem(string itemName) => AllItems[itemName];

        public void AddItem(Item item) 
        {
            if (Inventory[item.Name] == null)
            { 
                Inventory[item.Name] = item;
            } 
            else
            {
                DialogueHandler.PrintLine($"You already have a {item.Name}");
            }
        } 
    }
}
