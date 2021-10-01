using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.MapLocations;
using TextAdventureGame.Characters;

namespace TextAdventureGame.Mechanics
{
    public class Combat : IGameplay
    {
        public Location CurrentLocation { get; set; }
        public bool InCombat { get; set; }
        public Enemy Lolipop { get; protected set; }

        public Player PC { get; protected set; }
        public Gameplay Gameplay
        {
            get
            {
                return new Gameplay();
            }
        }

        /// <summary>
        /// Creates enemy and starts battle
        /// </summary>
        /// <param name="encounter"></param>
        public void Encounter(bool encounter, Player pc)
        {
            if (encounter)
            {
                if (PC == null)
                {
                    PC = pc;
                }

                this.Spawn();
                Console.WriteLine($"Oh, no! A {Lolipop.Name} pop has appeared!");
                InCombat = true;
                this.Prompt(PC);
            }
        }

        /// <summary>
        /// Creates and names lolipop enemy prior to encounter
        /// </summary>
        public void Spawn()
        {
            List<string> flavors = new List<string>
            {
                "cherry",
                "chocolate",
                "orange",
                "grape",
                "raspberry",
            };
            Random flavorChoice = new Random();
            int flavorIndex = flavorChoice.Next(0, 4);
            string flavor = flavors[flavorIndex];
            Enemy enemy = new Enemy();
            Lolipop = enemy;
            Lolipop.Name = flavor;
        }

        /// <summary>
        /// Handles combat inputs and resolves battle commands
        /// </summary>
        public void Prompt(Player player)
        {
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

            this.CheckInput(command, target);
        }

        /// <summary>
        /// Rolls for critical, damages oppnent, and increments sugar level
        /// </summary>
        public void Attack()
        {
            RollDamage();
            while (InCombat)
            {
                if (Lolipop.Health < 1 || PC.SugarLevel > 99)
                {
                    InCombat = false;

                }
                else
                {
                    this.Prompt(PC);
                }
            }
            EatCandy();
        }
        /// <summary>
        /// Ends battle and logs experience and sugar level
        /// </summary>
        public void EatCandy()
        {
            Console.WriteLine("Mmm! You've reached the delicious Tootsie Pop center!");
            Console.WriteLine($"Your sugar level is at {PC.SugarLevel}%");
            if (PC.SugarLevel > 50)
            {
                Console.WriteLine("Careful! If you're sugar level gets to 100, you'll crash! Try drinking some water.");
            }
            Console.WriteLine();
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.Clear();
            Gameplay.Prompt(PC);
        }

        /// <summary>
        /// Lists available commands at the time
        /// </summary>
        public void Help() //Needs implementing
        {
            Dictionary<string, string> helpDetails = new Dictionary<string, string>();
            helpDetails["Travel"] = "This lolipop is too thick! Run away!";
            helpDetails["Lick"] = "The only way to get to the center is to erode the candy coating. Get licking!";
            helpDetails["Help"] = "This... Well if you need an explanation, it lists the commands that will actually do things";

            foreach (KeyValuePair<string, string> item in helpDetails)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            Console.Read();
        }

        /// <summary>
        ///Rolls for critical and applies damage to enemy and increases player sugar level 
        /// </summary>
        public void RollDamage()
        {
            Random critical = new Random();
            double criticalChance = critical.NextDouble();
            int criticalDamage = 0;

            if (criticalChance > 0.7) //Deals critical damage
            {
                criticalDamage = PC.DamageMod + (int)(10 * critical.NextDouble());
                Console.Write("Chomp! ");
            }

            int damage = PC.DamageMod + criticalDamage;
            Console.WriteLine($"You managed to get in {damage} licks!");
            Lolipop.Health -= damage;
            PC.SugarLevel += 1;
        }

        /// <summary>
        /// Calls method based on input
        /// </summary>
        /// <param name="command"></param>
        /// <param name="target"></param>
        public void CheckInput(string command, string target)
        {
            if (command == "travel")
            {
                Console.WriteLine("Do you want to run? ");
                string input = Console.ReadLine();
                string[] inputSplit = input.Split(" ");

                if (input.ToLower() == "yes" || input.ToLower() == "y")
                {
                    if (inputSplit.Length > 1)
                    {
                        string location = inputSplit[1];
                        Location place = new Location();
                        place = place.StringToLocation(location);
                        if (place.Name == null)
                        {
                            Console.WriteLine("No such location exists. Please try again.");
                        }
                        else
                        {
                            location = target;
                        }
                        Gameplay.CheckLocation(location);
                    }
                }
                else 
                {
                    this.Prompt(PC);
                }

            }
            else if (command == "lick")
            {
                this.Attack();
            }
            else if (command == "help")
            {
                this.Help();
            }
            else
            {
                Console.WriteLine("Sorry. Please try again.");
                this.Prompt(PC);
            }
        }
    }
}

