using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.Characters;
using TextAdventureGame.MapLocations;

namespace TextAdventureGame.Gameplay
{
    public class Gameplay
    {
        public Player PC { get; set; }
        /// <summary>
        /// Creates and names the player character then saves the created player to the PC property
        /// </summary>
        /// <returns></returns>
        public Player CreatePlayer()
        {
            Console.Write("Please enter a name for your character: ");
            string input = Console.ReadLine();
            Player player = new Player();
            player.Name = input;
            Console.WriteLine();
            Console.WriteLine($"Welcome to the world, {player.Name}!");
            Console.WriteLine();
            this.PC = player;
            return this.PC;
        }
        /// <summary>
        /// Prompts player for input and handles inputted commands
        /// </summary>
        /// Needs Help command
        /// Needs handle for invalid inputs
        public virtual void Prompt()
        {
            Console.Write("What do you do?: ");
            string input = Console.ReadLine();
            string[] inputSplit = input.Split(" ");
            string command = inputSplit[0].ToLower();

            if (command == "travel" && inputSplit.Length > 1) //checks input for location input
            {
                string location = inputSplit[1];
                Location place = new Location();
                place = place.StringToLocation(location);
                if (place == null) //verifies location is in Map collection
                {
                    Console.WriteLine("No such location exists. Please try again.");
                }
                else
                {
                    this.Travel(place);
                }
            }
            else if (command == "lick") //handles combat command out of combat
            {
                Console.WriteLine("Save your licks for the candies.");
            }
            else if (command == "help")
            {
                this.Help();
            }
        }
        /// <summary>
        /// changes PC's current location and checks for enemy encounter
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public bool Travel(Location location)
        {
            bool encounter = false;
            Random encounterRandom = new Random();
            double encounterDouble = location.EncounterChance * encounterRandom.NextDouble();
            if (encounterDouble > 0.3)
            {
                 encounter = true;
            }
            return encounter;
        }
        /// <summary>
        /// displays possible commands and required inputs
        /// </summary>
        /// <returns></returns>
        public string Help() //Needs implementing
        {
            string helpDetails = null;
            return helpDetails;
        }
        /// <summary>
        /// changes and logs PC sugar level
        /// </summary>
        /// <param name="sugarLevel"></param>
        /// <returns></returns>
        public int EatCandy(int sugarLevel) //
        {
            PC.SugarLevel += sugarLevel;
            Console.WriteLine("Mmm! You've reached the delicious Tootsie Pop center!");
            Console.WriteLine($"Your sugar level is at {PC.SugarLevel}%");
            if (PC.SugarLevel > 50)
            {
                Console.WriteLine("Careful! If you're sugar level gets to 100, you'll crash! Try drinking some water.");
            }
            return PC.SugarLevel;
            
        }
    }
}
