using System;
using System.Collections.Generic;
using System.Text;
using TPGame.Models;

namespace TPGame.Interactables
{
    public class BuriedSwitch : Item
    {
        public BuriedSwitch()
        {
            Name = "Buried Switch";
            Description = "A metal plate with a blinking switch under a plastic plate. Where did this come from and what was it hiding?";
            GetLocation = "Backyard";
        }
    }
}
