using TPGame.Models;
using TPGame.Dictionaries;
using TPGame.Rooms;

namespace TPGame.Interactables
{
    public class BuriedSwitch : Interactable
    {
        public BuriedSwitch()
        {
            Name = "switch";
            Description = "A metal plate with a blinking switch under a plastic plate. Where did this come from and what was it hiding?";
        }

        public bool Hidden = true;

        public override void UseInteractable()
        {
            Collections.Rooms.Add(new HiddenRoom());
        }
    }
}
