using TPGame.Dictionaries;
using TPGame.Models;

namespace TPGame.Interactables
{
    public class Desk : Interactable
    {
        public Desk()
        {
            Name = "desk";
            Description = "A white wooden desk where you do all of your vaguely defined work. You pull out the drawer and see 4 BATTERIES. They're size C.";
        }

        public override void UseInteractable()
        {
            Collections.Inventory.Add(new Items.Batteries());
            Item lantern = Collections.Inventory.Find(item => item.Name == "camping lantern");
            if (lantern != null)
            {
                lantern.UseItem();
            }   
        }
    }
}
