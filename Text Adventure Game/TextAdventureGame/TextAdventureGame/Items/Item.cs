using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.Models;

namespace TextAdventureGame.Items
{
    public class Item
    {
        public string Name;
        public string Description;
        public string Location;
        public bool UsedUp;

        public virtual InputAction Use(Dictionary<string, Item> inventory, string roomName) { return null; }
    }
}
