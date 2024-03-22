using System;
using TPGame.Characters;

namespace TPGame.Handlers
{
    public static class CommandHandler
    {
        public static bool GameOver = false;

        /// <summary>
        /// Displays the title, creates the map, prompts the user for a player name, and displays opnening monologue
        /// </summary>
        public static void StartGame()
        {
#if RELEASE
            DialogueHandler.Title();
            DialogueHandler.OpeningMonologue();
            Console.ReadKey();
            Console.Clear();
#endif

            while (!GameOver)
            {
                InputHandler.HandleAction(UserInput.GetAction());
                DialogueHandler.PrintLine("");
            }
        }

        public static void WinGame() 
        {
            GameOver = true;
            DialogueHandler.PrintLine($"Congratulations! You have answered the age old question! It took {InputHandler.Character.GetLicks()} licks to get to the center of yourself.");
            Console.Read();
        }
    }
}
