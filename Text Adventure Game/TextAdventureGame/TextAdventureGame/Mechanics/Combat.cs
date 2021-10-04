using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.MapLocations;
using TextAdventureGame.Characters;

namespace TextAdventureGame.Mechanics
{
    public class Combat : Gameplay
    {
        public bool InCombat { get; set; }

        /// <summary>
        /// Creates enemy and starts battle
        /// </summary>
        /// <param name="encounter"></param>
        public Enemy Encounter()
        {
            Enemy = Enemy.Spawn();
            this.InCombat = true;
            return Enemy;
        }

        /// <summary>
        /// Rolls for critical, damages oppnent, and increments sugar level
        /// </summary>
        public void Attack()
        {
            if (!this.InCombat)
            {
                Console.WriteLine("Save your licks for the candies.");
                Console.WriteLine();
                Prompt.Execute(3);
            }
            else
            {
                int damage = RollDamage();
                Enemy.DamageEnemy(damage);
                Player.Execute(2);
                Prompt.Execute(3);
                if (Enemy.Health < 1)
                {
                    Execute(3);
                }
            }
        }

        /// <summary>
        /// Lists available commands at the time
        /// </summary>
        public override void Help() //Needs implementing
        {
            Dictionary<string, string> helpDetails = new Dictionary<string, string>();
            helpDetails["Move"] = "This lolipop is too thick! Run away!";
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
        public int RollDamage()
        {
            Random critical = new Random();
            double criticalChance = critical.NextDouble();
            int criticalDamage = 0;

            if (criticalChance > 0.7) //Deals critical damage
            {
                criticalDamage = Player.DamageMod + (int)(10 * critical.NextDouble());
                Console.Write("Chomp! ");
            }

            int damage = Player.DamageMod + criticalDamage;
            Console.WriteLine($"You managed to get in {damage} licks!");
            return damage;
        }

        public bool EndCombat()
        {
            Player.EatCandy();
            this.InCombat = false;
            return this.InCombat;
        }

        public override void Execute(int input)
        {
            switch (input)
            {
                case 1:
                    Encounter();
                    break;
                case 2:
                    Attack();
                    break;
                case 3:
                    RollDamage();
                    break;
                case 4:
                    EndCombat();
                    break;
                default:
                    break;
            }
        }
    }
}

