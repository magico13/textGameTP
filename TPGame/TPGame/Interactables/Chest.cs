using TPGame.Handlers;
using TPGame.Models;

namespace TPGame.Interactables
{
    public class Chest : Interactable
    {
        public Chest()
        {
            Name = "chest";
            Description = "A dusty, vintage looking chest. It's been locked since you received it from your grandmother.\n" +
                "You've tried unlocking it, but it seems stuck. The only way to open it would be to damage it.\n" +
                "You've refused to do that, choosing instead to keep it from harm in honor of Gram-Gram.";
        }

        public override void UseInteractable()
        {
            DialogueHandler.PrintLine("You haven't been able to open this chest without damaging it until now, when you continue to be unable to open it. The chest is probably more important than anything inside.");
        }
    }
}
