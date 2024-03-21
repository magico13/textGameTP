using System;
using TPGame.Models;
using TPGame.Dictionaries;

namespace TPGame.Interactables
{
    public class BuriedSwitch : Interactable
    {
        public BuriedSwitch()
        {
            Name = "Buried Switch";
            Description = "A metal plate with a blinking switch under a plastic plate. Where did this come from and what was it hiding?";
        }

        public override void UseInteractable()
        {
            Array.Find(Collections.Rooms, room => room.Name == "Hidden Room").Hidden = false;
        }
    }
}
