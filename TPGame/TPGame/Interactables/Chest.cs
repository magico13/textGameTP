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
    }
}
