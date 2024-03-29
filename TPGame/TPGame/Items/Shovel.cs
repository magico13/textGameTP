using TPGame.Dictionaries;
using TPGame.Handlers;
using TPGame.Interactables;
using TPGame.Models;
using TPGame.Rooms;

namespace TPGame.Items
{
    public class Shovel : Item
    {
        public Shovel() 
        {
            Name = "shovel";
            Description = "THIS NEEDS TO BE CHANGED";
        }

        public override void UseItem()
        {
            ((Backyard)(Collections.Rooms.Find(r => r.Name == "backyard"))).Interactables.Add("switch");
            ((BuriedSwitch)(Collections.VerifyInteractable("switch"))).Hidden = false;
            base.UseItem("THIS NEEDS TO BE CHANGED");
        }
    }
}
