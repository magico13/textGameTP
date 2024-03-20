using System.Collections.Generic;

namespace TPGame.Models
{
    public class Item
    {
        public string Name;
        public string Description;
        public string Location;
        public bool UsedUp;

        public virtual string Use(Dictionary<string, Item> inventory, string roomName) { return ""; }
    }
}
