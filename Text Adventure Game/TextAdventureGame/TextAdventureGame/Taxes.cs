using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TextAdventureGame
{
    public class Taxes
    {
        public List<string> Cheats = new List<string>();

        public List<string> GetCheats()
        {
            string filePath = Environment.CurrentDirectory + @"TextAdventureGame\obj\Taxes.txt";
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    Cheats.Add(line);

                }
            }
            return Cheats;
        }
    }
}
