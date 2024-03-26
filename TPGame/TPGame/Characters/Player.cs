using System;
using TPGame.Handlers;
using TPGame.Dictionaries;

namespace TPGame.Characters
{
    public class Player : Character
    {
        public Player() : base() { }
        public static int SugarLevel { get; set; } //if sugar level = 100, player crashes
        public int Experience { get; set; }
        public double CriticalThreshhold = 0.7;
        public int Licks { get; set; } = 0;

        /// <summary>
        ///Rolls for critical and applies damage to enemy and increases player sugar level 
        /// </summary>
        public int RollDamage()
        {
            double criticalChance = new Random().NextDouble();
            int criticalDamage = 0;

            if (criticalChance > CriticalThreshhold) //Deals critical damage
            {
                criticalDamage = (int)(
                    (Collections.Inventory.Find(item => item.Name == "guard") != null ? 20 : 10)
                    * new Random().NextDouble());
                if (criticalDamage < 1)
                {
                    criticalDamage = 1;
                }
                DialogueHandler.Print("Chomp! ");
            }

            return criticalDamage + (Collections.Inventory.Find(item => item.Name == "false teeth") != null ? 3 : 1);

        }

        public void EatCandy()
        {
            DialogueHandler.PrintLine("Mmm! You've reached the delicious Tootsie Pop center!");
            DialogueHandler.PrintLine($"Your sugar level is at {SugarLevel}%");
            if (SugarLevel > 50)
            {
                DialogueHandler.PrintLine("Careful! If you're sugar level gets to 100, you'll crash! Try drinking some water.");
            }
            Experience++;
            DialogueHandler.PrintLine($"You now have {Experience} lolipop stick" + (Experience > 1 ? "s" : "") + "!");
        }
    }
}
