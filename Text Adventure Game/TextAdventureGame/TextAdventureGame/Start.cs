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
            bool gameOver = false;

            //Title Sequence
            Title();

            GameCommand command = new GameCommand();

            //Create classes
            command.Execute(1);

            //Create map
            command.Execute(5);

            //Create a player
            command.Execute(2);

            //Displays opening monologue
            command.Execute(8);

            //gameOver condition needs implementing. game will loop back to prompt when all actions break
            while (!gameOver)
            {
                command.Execute(3);
            }

            //Closing Line
            GameCommand.PrintLine($"Congratulations! You have answered the age old question! It took {command.Licks} licks to get to the center of yourself.");
            Console.Read();
        }

        public static void Title()
        {
            string gameTitle = @"
                    ___   __ __    ___  _____ ______      ______   ___       ______  __ __    ___ 
                   /   \ |  |  |  /  _]/ ___/|      |    |      | /   \     |      ||  |  |  /  _]
                  |     ||  |  | /  [_(   \_ |      |    |      ||     |    |      ||  |  | /  [_ 
                  |  Q  ||  |  ||    _]\__  ||_|  |_|    |_|  |_||  O  |    |_|  |_||  _  ||    _]
                  |     ||  :  ||   [_ /  \ |  |  |        |  |  |     |      |  |  |  |  ||   [_ 
                  |     ||     ||     |\    |  |  |        |  |  |     |      |  |  |  |  ||     |
                   \__,_| \__,_||_____| \___|  |__|        |__|   \___/       |__|  |__|__||_____|
                         __    ___  ____   ______    ___  ____        ___   _____       ____         
                        /  ]  /  _]|    \ |      |  /  _]|    \      /   \ |     |     /    |        
                       /  /  /  [_ |  _  ||      | /  [_ |  D  )    |     ||   __|    |  o  |        
                      /  /  |    _]|  |  ||_|  |_||    _]|    /     |  O  ||  |_      |     |        
                     /   \_ |   [_ |  |  |  |  |  |   [_ |    \     |     ||   _]     |  _  |        
                     \     ||     ||  |  |  |  |  |     ||  .  \    |     ||  |       |  |  |        
                      \____||_____||__|__|  |__|  |_____||__|\_|     \___/ |__|       |__|__|        
                       ______   ___    ___   ______   _____ ____    ___      ____    ___   ____       
                      |      | /   \  /   \ |      | / ___/|    |  /  _]    |    \  /   \ |    \      
                      |      ||     ||     ||      |(   \_  |  |  /  [_     |  o  )|     ||  o  )     
                      |_|  |_||  O  ||  O  ||_|  |_| \__  | |  | |    _]    |   _/ |  O  ||   _/      
                        |  |  |     ||     |  |  |   /  \ | |  | |   [_     |  |   |     ||  |        
                        |  |  |     ||     |  |  |   \    | |  | |     |    |  |   |     ||  |        
                        |__|   \___/  \___/   |__|    \___||____||_____|    |__|    \___/ |__|        
                                                                     
";
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (gameTitle.Length / 2)) + "}", gameTitle));
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Yellow;
            string tagline1 = "How many licks does it take to get to the center of a Tootsie Pop?";
            string tagline2 = "The world may never know...";
            GameCommand.PrintLine(String.Format("{0," + ((Console.WindowWidth / 2) + (tagline1.Length / 2)) + "}", tagline1));
            GameCommand.PrintLine(String.Format("{0," + ((Console.WindowWidth / 2) + (tagline2.Length / 2)) + "}", tagline2));
            Console.WriteLine();
            string start = "Press any key to begin";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (start.Length / 2)) + "}", start));
            Console.ReadKey();
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
        }


    }
}
