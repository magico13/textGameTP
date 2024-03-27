using System;
using TPGame.Models;

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
            StartGame();
        }

        public static void LoseGame()
        {
            GameOver = true;
            DialogueHandler.PrintLine("Your head aches.");
            DialogueHandler.AddPause(300);
            DialogueHandler.PrintLine("Your vision blurs.");
            DialogueHandler.AddPause(300);
            DialogueHandler.PrintLine("Every muscle in your body spasms and twitches.");
            DialogueHandler.AddPause(300);
            DialogueHandler.PrintLine("You collapse to the ground. Your sugar level is too high! It's a sugar crash!");
            DialogueHandler.PrintLine("You can't go on. You'll have to start over and try again.");
            DialogueHandler.AddPause(300);
            DialogueHandler.PrintLine("Sorry, but your game is over.");
            Console.Read();
            StartGame();
        }   
    }
}
