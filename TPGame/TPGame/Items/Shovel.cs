using TPGame.Dictionaries;
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
            Description = "A metal shovel with a wooden shaft and a comfortable plastic grip. You haven't used it much since you planted your garden.";
        }

        public override void UseItem()
        {
            string message;
            if (!((Backyard)(Collections.Rooms.Find(r => r.Name == "backyard"))).Interactables.Contains("switch"))
            {
                ((Backyard)(Collections.Rooms.Find(r => r.Name == "backyard"))).Interactables.Add("switch");
                ((BuriedSwitch)(Collections.VerifyInteractable("switch"))).Hidden = false;
                message = "You scoop up the loose dirt with ease. It's not long before you uncover a strange metal plate with a SWITCH covered in a plastic case.";
            }
            else
            {
                message = "You think that you could get a good swing out of this, if necessary. You're not sure how the handle will withstand an attack.";
            }
            base.UseItem(message);
        }
    }
}
