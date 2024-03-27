using TPGame.Dictionaries;
using TPGame.Handlers;
using TPGame.Models;

namespace TPGame.Interactables
{
    public class WaterMain : Interactable
    {
        public WaterMain() 
        {
            Name = "water main";
            Description = "";
        }

        public bool On = false;

        public override void UseInteractable()
        {
            if (!On)
            {
                On = true;
                DialogueHandler.PrintLine("You turn the handle, which results in the pipes gently rumbling. You can hear a short burst of water running through the pipes.\n" +
                    "The pipes quickly go water. It seems there wasn't much water left.");
                ((Sink)Collections.AllInteractables.Find(i => i.Name == "kitchen sink")).WaterLevel += 60;
                ((Sink)Collections.AllInteractables.Find(i => i.Name == "bathroom sink")).WaterLevel += 60;
            }
            else 
            {
                DialogueHandler.PrintLine("Turning the handle off and on doesn't seem to be having any further effect.");
            }
        }
    }
}
