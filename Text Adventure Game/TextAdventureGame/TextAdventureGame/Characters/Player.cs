using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.MapLocations;
using TextAdventureGame.Mechanics;

namespace TextAdventureGame.Characters
{
    public class Player : Character
    {
        public Player(string name) : base()
        {
            Name = name;
            Health = 100 - SugarLevel;
            DamageMod = 1;
        }

        public int SugarLevel { get; set; } //if sugar level = 100, player crashes (maybe enter "sugar rush" at 100?)
        public int Experience { get; set; } //Needs expanding
        public int Licks { get; set; } = 0;

        public Player CreatePlayer(string name)
        {
            Player player = new Player(name);
            return player;
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
                criticalDamage = (int)(10 * critical.NextDouble());
                Console.Write("Chomp! ");
            }

            return criticalDamage;

        }

        public string EatCandy()
        {
            Start.PrintLine("Mmm! You've reached the delicious Tootsie Pop center!");
            Console.WriteLine();
            Start.PrintLine($"Your sugar level is at {SugarLevel}%");
            if (SugarLevel > 50)
            {
                Start.PrintLine("Careful! If you're sugar level gets to 100, you'll crash! Try drinking some water.");
            }
            Console.WriteLine();
            Experience++;
            string experienceGain = $"You now have {Experience} lolipop sticks!";
            return experienceGain;
        }

        public int GainSugar()
        {
            SugarLevel++;
            return SugarLevel;
        }
    }
}
