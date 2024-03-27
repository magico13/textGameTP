using System;
using System.Collections.Generic;

namespace TPGame.Models
{
    public class Room
    {
        public string Description { get; set; } = "";
        public string Image { get; set; } = "";
        public string Name { get; set; }
        public double EncounterChance { get; set; }

        public List<string> GetItems { get; set; } = [];

        public List<string> UsableItems { get; set; } = ["water bottle", "guard", "dentures", "mints"];

        public List<string> Interactables { get; set; } = [];

        public bool BossDefeated { get; set; } = false;

        public bool Hidden { get; set; } = false;

        /// <summary>
        /// Gets a random number and checks it agains the current locations encounter chance
        /// If the result is higher than 0.3, an encounter occurs
        /// </summary>
        public virtual bool RollEncounter() => (EncounterChance * new Random().NextDouble()) > 0.3;

        public virtual void Unlock() { }

        public virtual void DefeatBoss() { }
    }
}
