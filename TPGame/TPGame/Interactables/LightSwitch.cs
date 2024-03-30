using System;
using TPGame.Handlers;
using TPGame.Models;

namespace TPGame.Interactables
{
    public class LightSwitch : Interactable
    {
        public LightSwitch() 
        {
            Name = "light switch";
            Description = "While the light may be fine enough for you to see, you can always adjust the text and background to help see better.";
        }

        private bool On = true;

        public override void UseInteractable()
        {
            if (On)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                On = false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Clear();
                On = true;
            }
            base.UseInteractable($"*Click* You flick the lights " + (On ? "on" : "off") + ".");
        }
    }
}
