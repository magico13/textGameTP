using System;
using TextAdventureGame.Mechanics;

namespace TextAdventureGame
{
    public class Start
    {
        public static void Main(string[] args)
        {
            CommandHandler Game = new CommandHandler();
            //Main gameplay method
            Game.StartGame();
        }

        public static void PrintLine(string text, int delay = 25) //Causes text to be written at a delay simulating a typewriter effect and starts new line
        {
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(delay);
            }
            Console.WriteLine();
        }
        public static void Print(string text, int delay = 25) //Causes text to be written at a delay simulating a typewriter effect
        {
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(delay);
            }
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
            Start.PrintLine(String.Format("{0," + ((Console.WindowWidth / 2) + (tagline1.Length / 2)) + "}", tagline1));
            Start.PrintLine(String.Format("{0," + ((Console.WindowWidth / 2) + (tagline2.Length / 2)) + "}", tagline2));
            Console.WriteLine();
            string start = "Press any key to begin";
            Start.PrintLine(String.Format("{0," + ((Console.WindowWidth / 2) + (start.Length / 2)) + "}", start));
            Console.ReadKey();
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
        }
    }
}
