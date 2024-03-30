using TPGame.Dictionaries;
using TPGame.Handlers;
using TPGame.Models;

namespace TPGame.Interactables
{
    public class MedicineCabinet : Interactable
    {
        public MedicineCabinet() 
        {
            Name = "medicine cabinet";
            Description = "The mirror stands out from the wall. Behind it is your medicine cabinet, which may hold something of use.";
        }

        public override void UseInteractable()
        {
            base.UseInteractable("Behind the mirror are three shelves. Most of what's on them is not helpful" + (Collections.VerifyInventory("dentures") ? "" : ", except for the DENTURES. You might be able to do some damage with them") + ".");
        }
    }
}
