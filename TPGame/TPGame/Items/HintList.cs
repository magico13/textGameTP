using TPGame.Dictionaries;
using TPGame.Models;

namespace TPGame.Items
{
    public class HintList : Item
    {
        public HintList() 
        {
            Name = "hints";
            Description = "A list of steps of your master plan. Can be checked by typing \"Hint\" at any time.";
        }

        public override void UseItem()
        {
            Hints.DisplayHints();
        }

        public override void GetItem()
        {
            base.GetItem("You fold the notes until it can fit somewhere safe then tuck it away for future reference.");
        }
    }
}
