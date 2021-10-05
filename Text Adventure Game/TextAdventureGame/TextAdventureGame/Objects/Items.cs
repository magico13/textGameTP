using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.Mechanics;

namespace TextAdventureGame.Objects
{
    public class Items : GameCommand
    {
        public Items()
        {
            Inventory = new List<Items>();
        }
        public string Name { get; }
        public string Description { get; }
        public List<Items> Inventory { get; set; }

        /// <summary>
        /// Returns the description of an item
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public string CheckItem(string target)
        {
            foreach (Items item in Inventory)
            {
                if (item.Name == target)
                {
                    return item.Description;  
                }
            }
            return $"You don't have a {target}";
        }

        public void CheckInventory()
        {
            foreach (Items item in Inventory)
            {
                PrintLine(item.Name);
            }
        }
    }
}
