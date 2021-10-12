using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.Mechanics;

namespace TextAdventureGame.Characters
{
    public class Enemy : Character
    {
        public Enemy() : base()
        {
            Health = 10;
        }

        public Enemy Spawn()
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
            Enemy = new Enemy();
            Enemy.Name = flavor;
            return Enemy;
        }

        public int DamageEnemy(int damage)
        {
            this.Health -= damage;
            return this.Health;
        }

    }
}
