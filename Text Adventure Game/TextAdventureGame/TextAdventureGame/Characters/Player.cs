using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.MapLocations;
using TextAdventureGame.Mechanics;

namespace TextAdventureGame.Characters
{
    public class Player : Character
    {
        public Player() : base() { }
        public Player(string name) : base()
        {
            Name = name;
            Health = 100 - SugarLevel;
            DamageMod = 1;
        }

        public int SugarLevel { get; set; } //if sugar level = 100, player crashes (maybe enter "sugar rush" at 100?)

        public int Experience { get; set; } //Needs expanding

        public Player CreatePlayer(string name)
        {
            Player player = new Player(name);
            Player = player;
            Console.WriteLine();
            PrintLine($"Welcome to the world, {player.Name}!");
            Console.WriteLine();
            return Player;
        }

        public string EatCandy()
        {
            PrintLine("Mmm! You've reached the delicious Tootsie Pop center!");
            Console.WriteLine();
            PrintLine($"Your sugar level is at {SugarLevel}%");
            if (SugarLevel > 50)
            {
                PrintLine("Careful! If you're sugar level gets to 100, you'll crash! Try drinking some water.");
            }
            Console.WriteLine();
            Experience++;
            string experienceGain = $"You now have {Experience} lolipop sticks!";
            return experienceGain;
        }

        public int GainSugar()
        {
            this.SugarLevel++;
            return this.SugarLevel;
        }
    }
}
