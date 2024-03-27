using TPGame.Dictionaries;
using TPGame.Handlers;
using TPGame.Models;

namespace TPGame.Items
{
    public class Dentures : Item
    {
        public Dentures()
        {
            Name = "dentures";
            Description = "A set of false teeth that look weak but may be able to give you a little more bite. You can bite more aggressively with these on.";
        }

        public override void GetItem()
        {
            DialogueHandler.PrintLine("You grab the false teeth. Are they dentures? What's the difference?");
            if (Collections.VerifyInventory("guard"))
            {
                DialogueHandler.Print("You pop out your mouth guard while considering that maybe there isn't a difference. Maybe it has to do with they're made of? ");
            }
            DialogueHandler.PrintLine("You're so distracted that you put them over your teeth without thinking about the fact that you don't own any false teeth. Too late now.");
            InputHandler.Character.SetCriticalThreshhold(0.5);
        }

        public override void UseItem()
        {
            DialogueHandler.PrintLine("You pick at the false teeth. You don't know whose these were, and you hope they've been cleaned at some point...");
        }
    }
}
