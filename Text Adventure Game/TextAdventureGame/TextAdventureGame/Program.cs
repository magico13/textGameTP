using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAdventureGame.MapLocations;
using TextAdventureGame.Characters;
using TextAdventureGame.Gameplay;

namespace TextAdventureGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Ends game upon completion
            bool gameOver = false;

            //Title Sequence
            string gameTitle = "Quest to the Center of a Tootsie Pop";
            Console.WriteLine(gameTitle);
            Console.WriteLine("How many licks does it take to get to the center of a Tootsie Pop?");
            Console.WriteLine("The world may never know...");
            Console.WriteLine();

            //Character Creation
            Gameplay.Gameplay game = new Gameplay.Gameplay();
            game.CreatePlayer();
            //Gameplay loop
            while (!gameOver)
            {
                game.Prompt();
            }

            //Closing Line
            Console.WriteLine("Congratulations! You have answered the age old question!");
            Console.Read();
        }
        
    }
}
