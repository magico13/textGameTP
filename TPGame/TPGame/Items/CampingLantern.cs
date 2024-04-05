using TPGame.Dictionaries;
using TPGame.Rooms;
using TPGame.Models;

namespace TPGame.Items
{
    public class CampingLantern : Item
    {
        public CampingLantern()
        {
            Name = "lantern";
            Description = "\"For Use In Emergencies\" feels very appropriate right now. The lantern requires 4 'C' batteries, which are not included currently.";
        }

        public bool HasBatteries = false;

        public override void GetItem()
        {
            Attic attic = (Attic)Collections.Rooms.Find(r => r.Name == "Attic");
            attic.Description = attic.Description.Split("\n")[0];
            base.GetItem("You attach the handle to a strap on your tool belt. You'll need to add batteries when you have a chance.");
        }

        public override void UseItem()
        {
            if (HasBatteries)
            {
                base.UseItem("You click the switch on the lantern, creating a slightly blue glow.");
                ((Basement)(Collections.Rooms.Find(r => r.Name == "Basement"))).Light();
            }
            else
            {
                base.UseItem("You click the switch on the lantern, but nothing seems to be happening. The lantern needs batteries.");
            }
        }
    }
}

