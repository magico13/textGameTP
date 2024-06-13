using TPGame.Dictionaries;
using TPGame.Models;

namespace TPGame.Items
{
    public class Batteries : Item
    {
        public Batteries() 
        {
            Name = "batteries";
            Description = "Four C batteries that should have enough juice to power the lantern for as long as you need.";
        }

        public override void UseItem()
        {
            string message;
            CampingLantern campingLantern = (CampingLantern)Collections.CheckInventory("lantern");
            if (campingLantern != null && !campingLantern.HasBatteries)
            {
                campingLantern.HasBatteries = true;
                message = "You remove the pack to the lantern and insert the batteries. You test the lantern to see that it does turn on now. To preserve batteries, you switch the lantern back off.";
                Collections.RemoveUsedItem(Name);
            }
            else if (campingLantern.HasBatteries)
            {
                message = "You check the batteries in the lantern. They seem to be fine, so you shouldn't mess with them right now.";
            }
            else
            {
                message = "You roll the batteries in your hand. These could come in handy if you find something that could use them.";
            }
            base.UseItem(message);
        }

        public override void GetItem()
        {
            base.GetItem("You drop the batteries into a pocket on your belt until they are needed.");
        }
    }
}
