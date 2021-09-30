using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.MapLocations;
using TextAdventureGame.Characters;

namespace TextAdventureGame.Gameplay
{
    public class Combat : Gameplay
    {
        public bool InCombat { get; set; } = false;
        public Enemy Enemy { get; private set; }
        public Player CombatPC { get; set; }

        /// <summary>
        /// Creates enemy and starts battle
        /// </summary>
        /// <param name="encounter"></param>
        public void Encounter(bool encounter)
        {
            if (encounter)
            {
                CombatPC = base.PC;
                this.Spawn();
                Console.WriteLine($"Oh, no! A {Enemy.Name} pop has appeared!");
                InCombat = true;
                this.Battle();
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
            Enemy = enemy;
            Enemy.Name = flavor;
        }
        /// <summary>
        /// Checks to begin and end battle (for now it checks if player or enemy is null)
        /// </summary>
        public void Battle()
        {
            CombatPC = new Player();
            if (Enemy == null)
            {
                Console.WriteLine("The enemy disappeared");
            }
            else if (CombatPC == null)
            {
                Console.WriteLine("You disappeared");
            }
            if (base.PC == null)
            {
                Console.WriteLine("Your ghost disappeared");
            }
           
        }
        /// <summary>
        /// Handles combat inputs and resolves battle commands
        /// </summary>
        public override void Prompt()
        {
            Console.Write("What do you do?: ");
            string input = Console.ReadLine();
            string[] inputSplit = input.Split(" ");
            string command = inputSplit[0].ToLower();
            if (command == "lick")
            {
                this.Attack();
            }
            else if (command == "travel")
            {
                Console.WriteLine("Do you want to run? ");
                input = Console.ReadLine();
                inputSplit = input.Split(" ");

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
                            Travel(place);
                        }

                    }

                }


            }
        }
        /// <summary>
        /// Rolls for critical, damages oppnent, and increments sugar level
        /// </summary>
        public void Attack()
        {
            
            Random critical = new Random();
            double criticalChance = critical.NextDouble();
            int criticalDamage = 0;

            if (criticalChance > 0.7) //Deals critical damage
            {
                criticalDamage = CombatPC.DamageMod + (int)(10 * critical.NextDouble());
                Console.Write("Chomp! ");
            }

            int damage = CombatPC.DamageMod + criticalDamage;
            Console.WriteLine($"You managed to get in {damage} licks!");
            Enemy.Health -= damage;
            CombatPC.SugarLevel += 1;
            while (InCombat)
            {
                this.Prompt();
                if (Enemy.Health < 1 || CombatPC.SugarLevel > 99)
                {
                    InCombat = false;
                }
            }
            EatCandy(CombatPC.SugarLevel);
        }
    }
}
