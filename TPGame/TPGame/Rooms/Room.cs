using System;
using System.Collections.Generic;
using TextAdventureGame.Handlers;

namespace TextAdventureGame.MapLocations
{
    public class Room
    {
        public string Description { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public double EncounterChance { get; set; }

        /// <summary>
        /// Gets a random number and checks it agains the current locations encounter chance
        /// If the result is higher than 0.3, an encounter occurs
        /// </summary>
        /// <returns></returns>
        public bool RollEncounter()
        {
            bool encounter = false;
            Random encounterRandom = new Random();
            double encounterDouble = EncounterChance * encounterRandom.NextDouble();
            if (encounterDouble > 0.3)
            {
                encounter = true;
            }
            return encounter;
        }
    }
}
