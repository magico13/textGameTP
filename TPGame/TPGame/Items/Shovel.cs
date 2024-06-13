using TPGame.Commands;
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
            Description = "A metal shovel with a wooden shaft and a comfortable plastic grip. You haven't used it much since you planted your garden.";
        }

        public override void UseItem()
        {
            string message;
            if (!((Backyard)(Collections.Rooms.Find(r => r.Name == "Backyard"))).Interactables.Contains("switch"))
            {
                ((Backyard)(Collections.Rooms.Find(r => r.Name == "Backyard"))).Interactables.Add("switch");
                ((BuriedSwitch)(Collections.VerifyInteractable("switch"))).Hidden = false;
                message = "You scoop up the loose dirt with ease. It's not long before you uncover a strange metal plate with a SWITCH covered in a plastic case.";
            }
            else if (InputHandler.Map.CurrentLocation.Name == "Hidden Room")
            {
                message = "You unstrap your trusty shovel. With a barbaric shout, you wallop the king, bashing layer after layer from it's shell. You smash until the wooden handle on your shovel cracks and splinters in two. " + InputHandler.Character.AttackKing(25);
                Collections.RemoveUsedItem(Name);
            }
            else
            {
                message = "You think that you could get a good swing out of this, if necessary. You're not sure how the handle will withstand an attack.";
            }
            base.UseItem(message);
        }
    }
}
