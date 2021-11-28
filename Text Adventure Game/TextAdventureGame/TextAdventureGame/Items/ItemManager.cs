using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.Models;

namespace TextAdventureGame.Items
{
    public class ItemManager
    {
        public ItemManager() { }
        public string Name { get; }
        public string Description { get; set; }
        public Dictionary<string, Item> Inventory { get; set; } = new Dictionary<string, Item>();

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

        public InputAction UseItem(Item item, string roomName)
        {
            InputAction action = null;
            if (item != null && roomName != "")
            {
                action = item.Use(Inventory, roomName);
            }
            else if (item != null) 
            {
                action.Command = "reject";
            }
            return action;
        }

        public void CheckInventory()
        {
            if (Inventory.Count > 0)
            {
                foreach (KeyValuePair<string, Item> item in Inventory)
                {
                    Start.PrintLine(item.Value.Name);
                }
            }
            else
            {
                Start.PrintLine("You don't have anything on you right now");
            }
        }

        public Item CheckForItem(string itemName)
        {
            if (itemName != null && Inventory.ContainsKey(itemName))
            {
                Item item = Inventory[itemName];
                return item;
            }
            return null;
        }

        public Dictionary<string, Item> AddItem(Item item)
        {
            Inventory[item.Name] = item;
            return Inventory;
        }
    }
}
