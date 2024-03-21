using System;

namespace TPGame.Characters
{
    public class Enemy : Character
    {
        private readonly string[] Flavors = ["cherry", "chocolate", "orange", "grape", "raspberry"];
        
        public Enemy() : base()
        {
            string flavor = Flavors[new Random().Next(0, 5)];
            Name = flavor;
            Health = 10;
        }

        public Enemy(string bossName) 
        {
            Name = bossName;
            Health = bossName switch
            {
                "Bishop" => 20,
                "Knight" => 40,
                "Rook" => 60,
                "King" => 100,
                _ => 0
            };
        }

    }
}
