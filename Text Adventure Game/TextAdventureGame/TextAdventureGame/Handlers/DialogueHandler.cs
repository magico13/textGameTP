using System;

namespace TextAdventureGame.Handlers
{
    public static class DialogueHandler
    {
        public static void OpeningMonologue()
        {
            PrintLine( "You awaken to a bright new day as the sunshine pours through your window.\n\"What a beautiful day!\" you think to yourself." +
                    "\nIt's then that you hear suspicious rustling from the foot of your bed.\nAs you peer over the edge, you see wrappers strewn across your floor." +
                    "\nYou have always kept a stash of delicious Tootsie pops around,\nbut it seems they have gained sentience and are looking to get their revenge." +
                    "\nYou have trained for this moment so don't be scared.\nGather the supplies and figure out how your candies have turned so sour." +
                    "\nIt's time to be a hero...\nThe journey of any good hero starts by pushing any key to continue.");
        }

        /// <summary>
        /// Writes the text at a delay, simulating a typewriter effect and starts a new line
        /// </summary>
        /// <param name="text"></param>
        /// <param name="delay"></param>
        public static void PrintLine(string text, int delay = 10)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(delay);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Writes the text at a delay, simulating a typewriter effect
        /// </summary>
        /// <param name="text"></param>
        /// <param name="delay"></param>
        public static void Print(string text, int delay = 10) //Causes text to be written at a delay simulating a typewriter effect
        {
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(delay);
            }
        }

        /// <summary>
        /// Displays the title screen
        /// </summary>
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
            PrintLine(String.Format("{0," + ((Console.WindowWidth / 2) + (tagline1.Length / 2)) + "}", tagline1));
            PrintLine(String.Format("{0," + ((Console.WindowWidth / 2) + (tagline2.Length / 2)) + "}", tagline2));
            Console.WriteLine();
            string start = "Press any key to begin";
            PrintLine(String.Format("{0," + ((Console.WindowWidth / 2) + (start.Length / 2)) + "}", start));
            Console.ReadKey();
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
        }
    }
}
