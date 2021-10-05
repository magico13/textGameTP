using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.MapLocations;
using TextAdventureGame.Characters;

namespace TextAdventureGame.Mechanics
{
    public class Combat : GameCommand
    {
        /// <summary>
        /// Creates enemy and starts battle
        /// </summary>
        /// <param name="encounter"></param>
        public bool Encounter()
        {
            this.InCombat = true;
            return InCombat;
        }

        /// <summary>
        /// Lists available commands at the time
        /// </summary>
        

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
                criticalDamage =(int)(10 * critical.NextDouble());
                Console.Write("Chomp! ");
            }

            return criticalDamage;
            
        }
    }
}

