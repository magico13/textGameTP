using TPGame.Models;
using TPGame.Dictionaries;
using TPGame.Rooms;
using TPGame.Handlers;

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
        private bool On = false;

        public override void UseInteractable()
        {
            if (!Hidden && !On)
            {
                Collections.Rooms.Add(new HiddenRoom());
                DialogueHandler.PrintLine("You lift the plastic cover and flick the switch. You hear a loud rumbling noise. Something has changed.");
                On = true;
            }
            else if (Hidden)
            {
                DialogueHandler.PrintLine("What switch? There's no switch here.");
            }
            else
            {
                DialogueHandler.PrintLine("The switch is already on. Turning it off now won't help you in any way.");
            }
        }
    }
}
