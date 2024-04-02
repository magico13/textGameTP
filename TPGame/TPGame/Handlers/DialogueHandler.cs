using System;

namespace TPGame.Handlers
{
    public static class DialogueHandler
    {
        /// <summary>
        /// Displays text narrating start of game
        /// </summary>
        public static void OpeningMonologue()
        {
            PrintLine("You awaken to a bright new day as the sunshine pours through your window.\n\"What a beautiful day!\" you think to yourself." +
                    "\nIt's then that you hear suspicious rustling from the foot of your bed.\nAs you peer over the edge, you see wrappers strewn across your floor." +
                    "\nYou have always kept a stash of delicious Tootsie pops around,\nbut it seems they have gained sentience and are looking to get their revenge." +
                    "\nYou have trained for this moment so don't be scared.\nGather the supplies and figure out how your candies have turned so sour." +
                    "\nIt's time to be a hero...\n\nThe journey of any good hero starts by pushing any key to continue.");
        }

        /// <summary>
        /// Writes the text at a delay, simulating a typewriter effect and starts a new line
        /// </summary>
        /// <param name="text">string to be written</param>
        /// <param name="delay"># of milliseconds between each letter</param>
        public static void PrintLine(string text, int delay = 20)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(delay);
            }
            Console.WriteLine();
        }

        public static void PrintCentered(string text)
        {
            string image = String.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text);
            foreach (char c in image)
            {
                Console.Write(c);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Writes the text at a delay, simulating a typewriter effect
        /// </summary>
        /// <param name="text">string to be written</param>
        /// <param name="delay"># of milliseconds between each letter</param>
        public static void Print(string text, int delay = 20) //Causes text to be written at a delay simulating a typewriter effect
        {
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(delay);
            }
        }

        /// <summary>
        /// Creates a delay before writing next line or clearing console
        /// </summary>
        /// <param name="delay"># of milliseconds to wait</param>
        public static void AddPause(int delay = 100)
        {
            System.Threading.Thread.Sleep(delay);
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
                  |  O  ||  |  ||    _]\__  ||_|  |_|    |_|  |_||  O  |    |_|  |_||  _  ||    _]
                  |     ||  :  ||   [_ /  \ |  |  |        |  |  |     |      |  |  |  |  ||   [_ 
                  |     ||     ||     |\    |  |  |        |  |  |     |      |  |  |  |  ||     |
                   \__^_| \__^_||_____| \___|  |__|        |__|   \___/       |__|  |__|__||_____|
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            PrintCentered(gameTitle);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Yellow;
            string tagline1 = "How many licks does it take to get to the center of a Tootsie Pop?";
            string tagline2 = "The world may never know...";
            PrintCentered(tagline1);
            PrintCentered(tagline2);
            PrintLine("");
            string start = "Press any key to begin";
            PrintCentered(start);
            Console.ReadKey();
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
        }
    }
}
