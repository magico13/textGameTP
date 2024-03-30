using TPGame.Dictionaries;
using TPGame.Handlers;
using TPGame.Models;

namespace TPGame.Interactables
{
    public class Nightstand : Interactable
    {
        public Nightstand()
        {
            Name = "Nightstand";
            Description = "A small cherry nightstand with a reading lamp on top. The bulb has burned out, which you make a note to replace, intending to actually follow through this time.";
        }

        public override void UseInteractable()
        {
            string message;
            if (!Collections.VerifyInventory("guard"))
            {
                message = "You open the draw to discover a familiar case. It's your mouth GUARD that you left behind when this nightstand used to be in your room. It should still fit your mouth.";
            }
            else 
            {
                message = "You open each drawer but find nothing that could be of any assistance.";
            }
            base.UseInteractable(message);
        }
    }
}
