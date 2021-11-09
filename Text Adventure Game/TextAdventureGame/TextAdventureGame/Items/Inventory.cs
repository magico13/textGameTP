using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureGame.Objects
{
    public class Inventory
    {
        public Inventory(){ }
        public string Name { get; }
        public string Description { get; set; }
        public Dictionary<string, Inventory> InventoryDictionary { get; set; }

        /// <summary>
        /// Returns the description of an item
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public string CheckItem(string target)
        {
            if (InventoryDictionary.ContainsKey(target))
            {
                return InventoryDictionary[target].Description;
            }

            return $"You don't have a {target}";
        }

        public virtual bool UseItem(string use) { return false; }

        public void CheckInventory()
        {
            if (InventoryDictionary.Count > 0)
            {
                foreach (KeyValuePair<string, Inventory> item in InventoryDictionary)
                {
                    Start.PrintLine(item.Value.Name);
                }
            }
            else
            {
                Start.PrintLine("You don't have anything on you right now");
            }
        }

        public Inventory CheckForItem(string item)
        {
            if (InventoryDictionary.ContainsKey(item))
            {
                Inventory currentInventory = InventoryDictionary[item];
                return currentInventory;
            }
            return null;
        }

        public Dictionary<string, Inventory> CreateItems()
        {
            Dictionary<string, Inventory> inventory = new Dictionary<string, Inventory>
            {
                ["buried switch"] = new BuriedSwitch(),
                ["camping lantern"] = new CampingLantern(),
                ["computer"] = new Computer(),
                ["metal detector"] = new MetalDetector(),
                ["shovel"] = new Shovel(),
                ["tool belt"] = new ToolBelt(),
                ["water bottle"] = new WaterBottle()
            };
            return inventory;
        }
    }
}
