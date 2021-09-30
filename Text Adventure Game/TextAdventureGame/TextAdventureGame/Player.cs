using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureGame
{
    public class Player : Character
    {
        public Player(string name) : base(name)
        {
            DamageMod = 1;
            Health = 100;
            Characters = new List<Character>();
            CharacterHealths = new Dictionary<string, int>();

        }

        public Combat combat = new Combat();
        public bool InCombat { get; set; }

        public int Lick()
        {
            Enemy enemy = (Enemy)Characters[1];
            combat.Attack(Characters);
            return enemy.Health;
        }
        public void Prompt()
        {

            Console.Write("What do you do?: ");
            string input = Console.ReadLine();
            string[] inputSplit = input.Split(" ");
            string command = inputSplit[0].ToLower();

            if (command == "lick" && InCombat)
            {
                this.Lick();
            }
            else if (command == "travel" && inputSplit.Length > 1)
            {
                string location = inputSplit[1];
                Location place = new Location(null, 0);
                place = place.StringToLocation(location);
                if (place.Name == null)
                {
                    Console.WriteLine("No such location exists. Please try again.");
                }
                else
                {
                    this.Travel(place);
                }
            }
            else if (command == "help")
            {
                this.Help();
            }
        }
        public void Travel(Location location)
        {
            Random encounterRandom = new Random();
            double encounterDouble = location.EncounterChance * encounterRandom.NextDouble();
            if (encounterDouble > 0.5)
            {
                Combat combat = new Combat();
                combat.Encounter(CharacterHealths, Characters);
            }
        }
        public string Help()
        {
            string helpDetails= null;
            return helpDetails;
        }
    }
}
