using TPGame.Models;

namespace TPGame.Items
{
    public class CampingLantern : Item
    {
        public CampingLantern()
        {
            Name = "camping lantern";
            Description = "\"For Use In Emergencies\" feels very appropriate right now. The lantern requires 4 'C' batteries, which are not included currently.";
            GetLocation = "Attic";
        }
    }
}

