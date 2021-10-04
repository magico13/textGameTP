using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAdventureGame.Characters;
using TextAdventureGame.MapLocations;
using TextAdventureGame.Mechanics;

namespace TextAdventureGame
{
    public class Start
    {
        public static void Main(string[] args)
        {
            //Ends game upon completion
            //bool gameOver = false;

            //Title Sequence
            Title(); 

            Prompt prompt = new Prompt();
            GameCommand command = new GameCommand();
            //Create classes
            command.Execute(1);
            //Create map
            command.Execute(5);
            //Create a player
            command.Execute(2);

            command.Execute(3);

            //Closing Line
            Console.WriteLine("Congratulations! You have answered the age old question!");
            Console.Read();
        }

        public static void Title()
        {
            string gameTitle = "Quest to the Center of a Tootsie Pop";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (gameTitle.Length / 2)) + "}", gameTitle));
            Console.ResetColor();
            string tagline1 = "How many licks does it take to get to the center of a Tootsie Pop?";
            string tagline2 = "The world may never know...";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (tagline1.Length / 2)) + "}", tagline1));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (tagline2.Length / 2)) + "}", tagline2));
            Console.WriteLine();
            string start = "Press enter to begin";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (start.Length / 2)) + "}", start));
            Console.ReadLine();
            Console.Clear();
        }
    }
}
