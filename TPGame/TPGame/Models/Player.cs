using System;
using TPGame.Handlers;
using TPGame.Dictionaries;

namespace TPGame.Models
{
    public class Player
    {
        public Player() 
        {
            SugarLevel = 0;
        }

        private int SugarLevel; //if sugar level = 100, player crashes
        private int Experience;
        private int Licks;
        private double CriticalThreshhold = 0.95;

        /// <summary>
        ///Rolls for critical and applies damage to enemy and increases player sugar level 
        /// </summary>
        public int RollDamage()
        {
            int criticalDamage = 0;
            if (new Random().NextDouble() > CriticalThreshhold) //Deals critical damage
            {
                criticalDamage = (int)(
                    (Collections.VerifyInventory("dentures") ? 20 : 10)
                    * new Random().NextDouble());
                if (criticalDamage < 1)
                {
                    criticalDamage = 1;
                }
                DialogueHandler.Print("Chomp! ");
            }

            return criticalDamage + (Collections.VerifyInventory("guard") ? 3 : 1);

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

        public int GetLicks() => Licks;
        public int GetSticks() => Experience;
        public int GetSugar() => SugarLevel;
        public void IncrementSugar() => SugarLevel++;
        public void IncrementLicks() => Licks++;
        public void SetSugar(int change) => SugarLevel = change;
        public void SetCrit(double crit) => CriticalThreshhold = crit;
        public int RemoveSticks() => Experience -= 10;
    }
}
