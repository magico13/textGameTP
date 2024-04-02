using System;

namespace TPGame.Models
{
    public class Enemy
    {
        private readonly string[] Flavors = ["cherry", "chocolate", "orange", "grape", "raspberry"];
        public string Name;
        public int Health = 10;

        public Enemy()
        {
            Name = Flavors[new Random().Next(0, 5)];
        }

        public Enemy(string bossName)
        {
            Name = bossName;
            Health = bossName switch
            {
                "Bishop" => 20,
                "Knight" => 40,
                "Rook" => 60,
                "King" => 180,
                _ => 999
            };
        }

    }
}
