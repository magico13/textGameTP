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
        

        public void Encounter()
        {
            this.Spawn();
            Console.WriteLine($"Oh, no! A {Enemy.Name} pop has appeared!");
            InCombat = true;
            this.Battle();
        }
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

        public void Battle()
        {
            if (Enemy == null)
            {
                Console.WriteLine("The enemy disappeared");
            }
            else if (PC == null)
            {
                Console.WriteLine("You disappeared");
            }
            while (InCombat)
            {
                this.Prompt();
                if (Enemy.Health < 1 || base.PC.SugarLevel > 99)
                {
                    InCombat = false;
                }
            }
            Console.WriteLine("Mmm! You've reached the delicious Tootsie Pop center!");
            Console.WriteLine($"Your sugar level is at {base.PC.SugarLevel}%");
            if (base.PC.SugarLevel > 50)
            {
                Console.WriteLine("Careful! If you're sugar level gets to 100, you'll crash! Try drinking some water.");
            }
            base.EatCandy(base.PC.SugarLevel);
        }
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
                            base.Travel(place);
                        }

                    }

                }


            }
        }
        public void Attack()
        {
            Random critical = new Random();
            double criticalChance = critical.NextDouble();
            int criticalDamage = 0;
            if (criticalChance > 0.7)
            {
                criticalDamage = base.PC.DamageMod + (int)(10 * critical.NextDouble());
                Console.Write("Chomp! ");
            }
            int damage = base.PC.DamageMod + criticalDamage;
            Console.WriteLine($"You managed to get in {damage} licks!");
            Enemy.Health -= damage;
            base.PC.SugarLevel += 1;
        }
    }
}
