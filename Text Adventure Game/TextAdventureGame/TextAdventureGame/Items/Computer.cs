using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TextAdventureGame.Objects
{
    public class Computer : Inventory
    {
        public string itemLocation = "Office";

        public override bool UseItem(string use)
        {
            switch (use)
            {
                case "print cheats":
                    Cheat();
                    return true;

                case "search":
                    return true;

                default:
                    return false;
            }
        }

        public void Cheat()
        {
            Taxes taxes = new Taxes();
            List<string> cheats = taxes.GetCheats();
            foreach (string line in cheats)
            {
                Start.PrintLine(line);
            }
        }
    }
}

