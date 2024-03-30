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
            Description = "A pipe with a bright yellow handle that controls the flow of water to the entire house. It's currently " + (On ? "on":"off") + ".";
        }

        public bool On = false;

        /// <summary>
        /// Adds water to both sinks
        /// </summary>
        public override void UseInteractable()
        {
            string message;
            if (!On)
            {
                On = true;
                message = "You turn the handle, which results in the pipes gently rumbling. You can hear a short burst of water running through the pipes.\n" +
                    "The pipes quickly go quiet. It seems there wasn't much water left.";
                ((Sink)Collections.VerifyInteractable("kitchen sink")).WaterLevel += 50;
                ((Sink)Collections.VerifyInteractable("bathroom sink")).WaterLevel += 50;
            }
            else 
            {
                message = "Turning the handle off and on doesn't seem to be having any further effect.";
            }
            base.UseInteractable(message);
        }
    }
}
