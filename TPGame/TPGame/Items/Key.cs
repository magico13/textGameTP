using System;
using TPGame.Dictionaries;
using TPGame.Models;

namespace TPGame.Items
{
    public class Key : Item
    {
        public Key()
        {
            Name = "key";
            Description = "A bronze key with a green rubber cap to identify it as the garage key. The rubber is worn down where you have picked at it.";
            Uses = 999;
        }

        public override void GetItem()
        {
            Collections.Rooms.Find(room => room.Name == "Garage").Unlock();
        }
    }
}
