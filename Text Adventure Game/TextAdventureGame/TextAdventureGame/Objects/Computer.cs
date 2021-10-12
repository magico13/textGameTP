using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TextAdventureGame.Objects
{
    public class Computer : Items
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
            Taxes TotallyTaxesNothingElse = new Taxes();
            List<string> cheats = TotallyTaxesNothingElse.GetCheats();

            string currentPath = Environment.CurrentDirectory + @"\TootsiePopWalkthrough.txt";
            using (StreamWriter writer = new StreamWriter(currentPath, false))
            {
                foreach (string line in cheats)
                {
                    writer.WriteLine(line);
                }
            }
        }
    }
}
