using TPGame.Dictionaries;
using TPGame.Models;

namespace TPGame.Interactables
{
    public class Couch : Interactable
    {
        public Couch()
        {
            Name = "couch";
            Description = "A comfortable couch that is a lovely forest green color. The couch remains the centerpiece of your living room design aesthetic,\n" +
                "but more importantly, the cushions pull out. A good cleaning seems to be in order.";
        }

        public override void UseInteractable()
        {
            string message = "You rumage through the couch cushions, pushing aside clumps of dust and indistinguishable crumbs.";
            if (!Collections.VerifyInventory("key"))
            {
                message += " Your hands brush against something metallic. You see a small silver KEY with a green rubber top, meaning this is the KEY to the GARAGE.";
            }
            if (!Collections.VerifyInventory("mints"))
            {
                message += " Some small white candies roll out from behind a cushion. Even from here, you can smell that these are MINTS. Might come in handy, somehow.";
            }
            base.UseInteractable(message);
        }
    }
}
