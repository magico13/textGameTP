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
            DialogueHandler.PrintLine("Behind the mirror are three shelves. Most of what's on them is not helpful, except for the FALSE TEETH. You might be able to do some damage with them");
        }
    }
}
