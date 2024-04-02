using TPGame.Commands;
using TPGame.Handlers;
using TPGame.Models;

namespace TPGame.Interactables
{
    public class HomeGym : Interactable
    {
        public HomeGym() 
        {
            Name = "home gym";
            Description = "A home workout machine with adjustable weights that you bought cheaply and used briefly. If you think you could lift it, the weights might be able to do some damage.";
        }

        public override void UseInteractable()
        {
            if (InputHandler.Character.Lolipop.Health > 0)
            {
                InputHandler.Character.AttackBoss("You grab the knight and lift as much weight as you can manage. You force the knight between the weights and ignore all of your gym etiquette, smashing the knight to pieces. One more lick ought to reach the core.");
            }
            else
            {
                base.UseInteractable("Your muscles are sore and exhausted from your adventures so far. It's nice you want to work out more, but now is not the time.");
            }
        }
    }
}
