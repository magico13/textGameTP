using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool gameOver = false;
            Location map = new Location();
            map.CreateMap();
            string gameTitle = "Quest to the Center of a Tootsie Pop";
            Console.WriteLine(gameTitle);
            Console.WriteLine("How many licks does it take to get to the center of a Tootsie Pop?");
            Console.WriteLine("The world may never know...");
            Console.WriteLine();
            Console.Write("Please enter a name for your character: ");
            string input = Console.ReadLine();
            Player player = new Player(input);
            Console.WriteLine();
            Console.WriteLine($"Welcome to the world, {player.Name}!");
            Console.WriteLine();
            while (!gameOver)
            {
                player.Prompt();
            }
            Console.WriteLine("Congratulations! You have answered the age old question!");
        }
        
    }
}
