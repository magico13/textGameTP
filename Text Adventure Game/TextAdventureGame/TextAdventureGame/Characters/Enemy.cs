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

        public override void Execute(int input) { }

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
            Enemy.Name = flavor;
            Console.WriteLine($"Oh, no! A {Enemy.Name} pop has appeared!");
            return Enemy;
        }

        public void DamageEnemy(int damage)
        {
            Health -= damage;
            if (Health < 1)
            {
                Combat.EndCombat();
            }
        }

    }
}
