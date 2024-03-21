using System;
using TPGame.Handlers;

namespace TPGame.Characters
{
    public class Player : Character
    {
        public Player() : base()
        {
            DamageMod = 1;
        }

        public int SugarLevel { get; set; } //if sugar level = 100, player crashes (maybe enter "sugar rush" at 100?)
        public int Experience { get; set; } //Needs expanding
        public int Licks { get; set; } = 0;

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
                DialogueHandler.Print("Chomp! ");
            }

            return criticalDamage + DamageMod;

        }

        public string EatCandy()
        {
            DialogueHandler.PrintLine("Mmm! You've reached the delicious Tootsie Pop center!");
            DialogueHandler.PrintLine($"Your sugar level is at {SugarLevel}%");
            if (SugarLevel > 50)
            {
                DialogueHandler.PrintLine("Careful! If you're sugar level gets to 100, you'll crash! Try drinking some water.");
            }
            Experience++;
            string experienceGain = $"You now have {Experience} lolipop stick" + (Experience > 1?"s":"") + "!";
            return experienceGain;
        }
    }
}
