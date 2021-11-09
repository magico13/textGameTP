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

        private List<string> Flavors { get { return new List<string>() {"cherry", "chocolate", "orange", "grape", "raspberry"}; } }

        public Enemy Spawn()
        {
            Random flavorChoice = new Random();
            string flavor = Flavors[flavorChoice.Next(0, 5)];
            Enemy enemy = new Enemy
            {
                Name = flavor
            };
            return enemy;
        }

        public int DamageEnemy(int damage)
        {
            this.Health -= damage;
            return this.Health;
        }
    }
}
