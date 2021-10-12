using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.MapLocations;
using TextAdventureGame.Mechanics;

namespace TextAdventureGame.Objects
{
    public class Items : GameCommand
    {
        public Items()
        {
            CurrentInventory = new Dictionary<string, Items>();
            PossibleInventory = new Dictionary<string, Items>();
        }
        public string Name { get; }
        public string Description { get; }
        public Dictionary<string, Items> CurrentInventory { get; set; }
        public Dictionary<string, Items> PossibleInventory { get; set; }
        public bool Usable { get; set; }
        public string ItemLocation { get; set; }
        /// <summary>
        /// Returns the description of an item
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public string CheckItem(string target)
        {
                if (CurrentInventory.ContainsKey(target))
                {
                    return CurrentInventory[target].Description;  
                }

            return $"You don't have a {target}";
        }

        public virtual bool UseItem(string use) { return false; }

        public void CheckInventory()
        {
            if (CurrentInventory.Count > 0)
            {
                foreach (KeyValuePair<string, Items> item in CurrentInventory)
                {
                    PrintLine(item.Value.Name);
                }
            }
            else 
            {
                PrintLine("You don't have anything on you right now");
            }
        }

        public Items CheckForItem(string item)
        {
            if (PossibleInventory.ContainsKey(item))
            {
                CurrentInventory[item] = PossibleInventory[item];
                return CurrentInventory[item];
            }
            return null;
        }

        public void CreateItems()
        {
            PossibleInventory["batteries"] = new Batteries();
            PossibleInventory["buried switch"] = new BuriedSwitch();
            PossibleInventory["camping lantern"] = new CampingLantern();
            PossibleInventory["computer"] = new Computer();
            PossibleInventory["metal detector"] = new MetalDetector();
            PossibleInventory["shovel"] = new Shovel();
            PossibleInventory["tool belt"] = new ToolBelt();
            PossibleInventory["water bottle"] = new WaterBottle();
        }
    }
}
