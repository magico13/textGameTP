using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.Characters;
using TextAdventureGame.MapLocations;

namespace TextAdventureGame.Mechanics
{
    public class Gameplay : IGameplay
    {
        public Location CurrentLocation { get; protected set; }
        public Player PC { get; private set; }
        public Enemy Lolipop { get; }
        public Combat Combat
        {
            get
            {
                return new Combat();
            }
        }

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
            Location start = new Location();
            CurrentLocation = start;
            return this.PC;
        }

        /// <summary>
        /// Prompts player for input and generates commands and targets
        /// </summary>
        /// Needs Help command
        /// Needs handle for invalid inputs
        public virtual void Prompt(Player player)
        {
            CheckForPlayer(player);

            bool validInput;
            string input;

            do
            {
                validInput = true;
                Console.Write("What do you do?: ");
                input = Console.ReadLine();
                if (input == null || input == "")
                {
                    Console.WriteLine("Sorry. Please try again.");
                    validInput = false;
                }
            } while (!validInput);

            string[] inputSplit = input.Split(" ");
            string command = inputSplit[0].ToLower();
            string target = "";

            if (inputSplit.Length > 1)
            {
                target = inputSplit[1].ToLower();
            }

            CheckInput(command, target);
        }

        /// <summary>
        /// changes PC's current location and checks for enemy encounter
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public void Travel(Location location)
        {
            bool encounter = false;
            Random encounterRandom = new Random();
            double encounterDouble = location.EncounterChance * encounterRandom.NextDouble();
            if (encounterDouble > 0.3)
            {
                encounter = true;
            }
            Combat.Encounter(encounter, PC);
        }

        /// <summary>
        /// Displays possible commands and required inputs
        /// </summary>
        /// <returns></returns>
        public void Help()
        {
            Dictionary<string, string> helpDetails = new Dictionary<string, string>();
            helpDetails["Travel"] = "Go to a different room (add room after a space)";
            helpDetails["Lick"] = "I mean... I guess you could but there's nothing to lick right now so I wouldn't";
            helpDetails["Help"] = "This... Well if you need an explanation, it lists the commands that will actually do things";
            helpDetails["Rooms"] = "This house is so big that sometimes you forget how many rooms there are. This will list them all for you";

            foreach (KeyValuePair<string, string> item in helpDetails)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            Console.WriteLine();
            this.Prompt(PC);
        }

        /// <summary>
        /// Initial prompt to start game
        /// </summary>
        public void Prompt()
        {
            this.Prompt(PC);
        }

        /// <summary>
        /// Redirects player based on input or returns to prompt if blank or null
        /// </summary>
        /// <param name="command"></param>
        /// <param name="target"></param>
        public void CheckInput(string command, string target)
        {
            if (command == "travel") //checks input for location input
            {
                string location;
                if (target == "" || target == null)
                {
                    Console.WriteLine("Which room?");
                    location = Console.ReadLine().ToLower();
                }
                else
                {
                    location = target;
                }
                CheckLocation(location);
            }
            else if (command == "lick") //handles combat command out of combat
            {
                Console.WriteLine("Save your licks for the candies.");
                Console.WriteLine();
                this.Prompt(PC);
            }
            else if (command == "rooms")
            {
                CurrentLocation.CheckMap();
            }
            else if (command == "help")
            {
                Console.WriteLine();
                this.Help();
            }
            else
            {
                Console.WriteLine("Sorry. Please try again.");
                Console.WriteLine();
                this.Prompt(PC);
            }
        }

        /// <summary>
        /// Verifies input location is in map collection
        /// </summary>
        /// <param name="location"></param>
        public void CheckLocation(string location)
        {
            Location place = new Location();
            place = place.StringToLocation(location);
            if (place == null)
            {
                Console.WriteLine("No such location exists. Please try again.");
                this.CheckInput("travel", "");

            }
            else if (place == CurrentLocation)
            {
                Console.WriteLine("You're already there");
                this.CheckInput("travel", "");
            }
            else
            {
                this.CurrentLocation = place;
                this.Travel(place);
            }
        }

        /// <summary>
        /// Checks to make sure PC exists and creates a new player if PC is null
        /// </summary>
        /// <param name="player"></param>
        public void CheckForPlayer(Player player)
        {
            if (player == null)
            {
                CreatePlayer();
            }
            else
            {
                PC = player;
            }
        }
    }
}
