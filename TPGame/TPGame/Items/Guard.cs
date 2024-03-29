using System;
using TPGame.Handlers;
using TPGame.Models;

namespace TPGame.Items
{
    public class Guard : Item
    {
        public Guard()
        {
            Name = "guard";
            Description = "A plastic mouth guard that you found again just recently. You constantly feel it against the roof of your mouth, but it will protect your teeth from the sugar.";
        }

        public override void GetItem()
        {
            DialogueHandler.PrintLine("You open the case and remove the mouth guard. It looks clean enough, and, without any water to rinse it, you don't have any other options. You pop it into your mouth and smile aggresively, excited to take on more lolipops.");
        }

        public override void UseItem()
        {
            string message = new Random().Next(2) switch
            {
                0 => "You dislodge the guard with your tongue and chew gently on the rubber. It doesn't do much but seems to make you feel a little better.",
                1 => "You reach in and adjust the guard in your mouth, relieving some oral discomfort.",
                _ => "ERROR! RANDOM FAILURE OCCURRED! Or you messed with my code. Don't do that. I worked hard on this."
            };
            DialogueHandler.PrintLine(message);
        }
    }
}
