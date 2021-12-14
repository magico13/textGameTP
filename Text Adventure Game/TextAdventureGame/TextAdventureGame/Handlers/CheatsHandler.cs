using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TextAdventureGame.Items;

namespace TextAdventureGame
{
    public class CheatsHandler
    {
        private readonly Cheats cheats = new Cheats();
        private readonly string filePath = Environment.CurrentDirectory + @"TextAdventureGame\obj\Taxes.txt";

        public List<string> GetCheats()
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        cheats.CheatsList.Add(line);

                    }
                }
                return cheats.CheatsList;
            }
            catch (IOException ex)
            {
                Console.WriteLine("Sorry. Couldn't find a walkthrough... cheater");
                return new List<string>();
            }
        }

        public void PrintCheatsToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    foreach (string line in cheats.CheatsList)
                    {
                        writer.WriteLine(line);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Sorry. Couldn't find a walkthrough... cheater");
            }
        }
    }
}
