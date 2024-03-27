using TPGame.Dictionaries;
using TPGame.Handlers;
using TPGame.Rooms;
using TPGame.Models;

namespace TPGame.Items
{
    public class CampingLantern : Item
    {
        public CampingLantern()
        {
            Name = "camping lantern";
            Description = "\"For Use In Emergencies\" feels very appropriate right now. The lantern requires 4 'C' batteries, which are not included currently.";
        }

        public bool HasBatteries = false;

        public override void UseItem()
        {
            if (HasBatteries)
            {
                ((Basement)(Collections.Rooms.Find(r => r.Name == "basement"))).IsDark = false;
                DialogueHandler.PrintLine("You click the switch on the lantern, creating a slightly blue glow.");
            }
            else
            {
                DialogueHandler.PrintLine("You click the switch on the lantern, but nothing seems to be happening. The lantern needs batteries.");
            }
        }
    }
}

