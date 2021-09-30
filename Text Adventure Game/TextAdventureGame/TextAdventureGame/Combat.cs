using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureGame
{
    public class Combat
    {
        public bool InCombat { get; set; }
        public Dictionary<string, int> CharacterHealths { get; }
        public List<Character> Characters { get;  }
        public int Attack(List<Character>Characters)
        {
            Player player = (Player)Characters[0];
            Enemy enemy = (Enemy)Characters[1];
            Random critical = new Random();
            double criticalChance = critical.NextDouble();
            int criticalDamage = 0;
            if (criticalChance > 0.7)
            {
                criticalDamage = player.DamageMod + (int)(10 * critical.NextDouble());
                enemy.Health -= criticalDamage;
            }
            int damage = player.DamageMod + criticalDamage;
            Console.WriteLine($"You managed to get in {damage} licks!");
            enemy.Health -= damage;
            player.Health -= 1;
            return enemy.Health;
        }
        public void Battle(Enemy target, List<Character>Characters) 
        {
            Player player = (Player)Characters[0];
            while (target.Health > 0 && player.Health > 0)
            {
                player.Prompt();
            }
            Console.WriteLine("Mmm! You've reached the delicious Tootsie Pop center!");
            Console.WriteLine($"Ouch! Your health is currently {player.Health}");

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
            Enemy target = new Enemy(flavor);
            Console.WriteLine($"Oh, no! A {flavor} pop has appeared!");
            InCombat = true;
            return target;
        }
        public void Encounter(Dictionary<string, int> CharacterHealths, List<Character> Characters)
        {
            Enemy target = this.Spawn();
            Character lolipop = target;
            CharacterHealths[lolipop.Name] = lolipop.Health;
            Characters.Add(lolipop);
            this.Battle(target, Characters);
        }
    }
}
