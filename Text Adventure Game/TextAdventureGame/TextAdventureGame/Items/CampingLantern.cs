using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.MapLocations;

namespace TextAdventureGame.Objects
{
    public class CampingLantern : Inventory
    {
        private bool HasBatteries;

        private bool TurnedOn;

        public CampingLantern() 
        { 
            Description = "\"For Use In Emergencies\" feels very appropriate right now. The lantern requires 4 'C' batteries, which are not included currently.";
            HasBatteries = false;
            TurnedOn = false;
        }

        public void GetBatteries()
        {
            Description.Replace("The lantern requires 4 'C' batteries, which are not included currently.", "The lantern has 4 C batteries. It gives off a brilliant blue glow when turned on.");
            HasBatteries = true;
        }

        public override bool UseItem(string use)
        {
            switch (use)
            {
                case "power on":
                    if (!TurnedOn && HasBatteries)
                    {
                        TurnedOn = true;
                        Start.PrintLine("The lantern is on");
                        return true;
                    }
                    else 
                    {
                        Start.PrintLine("The lantern is already on");
                        return false;
                    }

                case "power off":
                    if (TurnedOn)
                    {
                        TurnedOn = false;
                        Start.PrintLine("The lantern is off");
                        return true;
                    }
                    else
                    {
                        Start.PrintLine("The lantern is already off");
                        return false;
                    }

                case "nothing":
                    return true;

                default:
                    Start.PrintLine("Invalid input");
                    return false;
            }
        }
    }
}

