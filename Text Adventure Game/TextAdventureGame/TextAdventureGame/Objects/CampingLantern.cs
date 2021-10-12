using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.MapLocations;

namespace TextAdventureGame.Objects
{
    public class CampingLantern : Items
    {
        public string itemLocation = "Attic";

        public string Description = "\"For Use In Emergencies\" feels very appropriate right now. The lantern requires 4 'C' batteries, which are not included currently.";

        public bool HasBatteries = false;

        public bool TurnedOn = false;

        public void GetBatteries()
        {
            Description.Replace("The lantern requires 4 'C' batteries, which are not included currently.", "The lantern has 4 C batteries. It gives off a brilliant blue glow when turned on.");
        }

        public override bool UseItem(string use)
        {
            switch (use)
            {
                case "power on":
                    if (!TurnedOn)
                    {
                        TurnedOn = true;
                        PrintLine("The lantern is on");
                        return true;
                    }
                    else 
                    {
                        PrintLine("The lantern is already on");
                        return false;
                    }

                case "power off":
                    if (TurnedOn)
                    {
                        TurnedOn = false;
                        PrintLine("The lantern is off");
                        return true;
                    }
                    else
                    {
                        PrintLine("The lantern is already off");
                        return false;
                    }

                case "use batteries":
                    if (Inventory.CurrentInventory.ContainsKey("Batteries"))
                    {
                        HasBatteries = true;
                    }
                    return true;
                case "nothing":
                    return true;
                default:
                    PrintLine("Invalid input. Use \"Power On\" to turn on the lantern, \"");
                    return false;
            }
        }
    }
}

