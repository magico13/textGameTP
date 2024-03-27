using TPGame.Dictionaries;
using TPGame.Handlers;
using TPGame.Models;

namespace TPGame.Items
{
    public class Batteries : Item
    {
        public Batteries() 
        {
            Name = "batteries";
            Description = "Four C batteries that should have enough juice to power the camping lantern for as long as you need.";
        }

        public override void UseItem()
        {
            CampingLantern campingLantern = (CampingLantern)Collections.CheckInventory("camping lantern");
            if (campingLantern != null && !campingLantern.HasBatteries)
            {
                campingLantern.HasBatteries = true;
                DialogueHandler.PrintLine("You remove the pack to the lantern and insert the batteries. You test the lantern to see that it does turn on now. To preserve batteries, you switch the lantern back off.");
            }
            else if (campingLantern.HasBatteries)
            {
                DialogueHandler.PrintLine("You check the batteries in the lanter. They seem to be fine, so you shouldn't mess with them right now.");
            }
            else
            {
                DialogueHandler.PrintLine("You roll the batteries in your hand. These could come in handy if you find something that could use them.");
            }
        }

    }
}
