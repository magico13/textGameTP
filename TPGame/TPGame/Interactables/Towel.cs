using TPGame.Handlers;
using TPGame.Models;

namespace TPGame.Interactables
{
    public class Towel : Interactable
    {
        public Towel()
        {
            Name = "towel";
            Description = "A solid blue towel that has slightly faded from being washed too many times. You still remember the day you bought it. Though it's color is fading, the feel still can't be beat.";
        }

        private bool Used = false;

        public override void UseInteractable()
        {
            if (!Used)
            {
                DialogueHandler.PrintLine("You use the towel to wipe off your accumulated sweat. It's been rough going and taking a break to towel off has reinvigorated you.");
                Used = true;
                Description += "The towel is slightly damp from your sweat.";
            }
            else
            {
                DialogueHandler.PrintLine("The towel is still damp and smells slightly. Probably best to not use it until you can wash it.");
            }
        }
    }
}
