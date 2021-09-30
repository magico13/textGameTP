using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.Characters;
using TextAdventureGame.MapLocations;

namespace TextAdventureGame.Gameplay
{
    public class Gameplay
    {
        public Gameplay() { }
        public Player PC { get; protected set; }
        public Player CreatePlayer()
        {
            Console.Write("Please enter a name for your character: ");
            string input = Console.ReadLine();
            Player player = new Player();
            player.Name = input;
            Console.WriteLine();
            Console.WriteLine($"Welcome to the world, {player.Name}!");
            Console.WriteLine();
            PC = player;
            return PC;
        }
        public virtual void Prompt()
        {
            Console.Write("What do you do?: ");
            string input = Console.ReadLine();
            string[] inputSplit = input.Split(" ");
            string command = inputSplit[0].ToLower();
            if (command == "travel" && inputSplit.Length > 1)
            {
                string location = inputSplit[1];
                Location place = new Location();
                place = place.StringToLocation(location);
                if (place == null)
                {
                    Console.WriteLine("No such location exists. Please try again.");
                }
                else
                {
                    this.Travel(place);
                }
            }
            else if (command == "lick")
            {
                Console.WriteLine("Save your licks for the candies.");
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
            if (encounterDouble > 0.3)
            {
                Combat combat = new Combat();
                combat.Encounter();
            }
        }
        public string Help()
        {
            string helpDetails = null;
            return helpDetails;
        }
        public void EatCandy(int sugarLevel)
        {
            PC.SugarLevel = sugarLevel;
        }
    }
}
