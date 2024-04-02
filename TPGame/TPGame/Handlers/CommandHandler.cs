using System;
using System.Collections.Generic;
using TPGame.Commands;
using TPGame.Dictionaries;
using TPGame.Interactables;
using TPGame.Items;
using TPGame.Models;
using TPGame.Rooms;

namespace TPGame.Handlers
{
    public static class CommandHandler
    {
        private static bool GameOver = false;

        /// <summary>
        /// Displays the title, displays opnening monologue, prompts user for tutorial, and handles main gameplay loop
        /// </summary>
        public static void StartGame()
        {
            GameOver = false;
#if RELEASE
            DialogueHandler.Title();
            DialogueHandler.OpeningMonologue();
            Console.ReadKey();
            Console.Clear();
#endif
            while (!GameOver)
            {
                if (UserInput.GetBool("Do you want a tutorial?: "))
                {
                    TutorialHandler.Teach();
                }
                else
                {
                    DialogueHandler.PrintLine("I understand. Let's just drop you right into it.");
                    DialogueHandler.AddPause(600);
                    Console.Clear();
                    DialogueHandler.PrintLine("You hop out of your bed. You're in your master bedroom.");
                    Console.WriteLine();
                }

                InputHandler.HandleAction(UserInput.GetAction());
                DialogueHandler.PrintLine("");
            }
        }

        /// <summary>
        /// Display win game text and end game
        /// Returns player to start screen
        /// </summary>
        public static void WinGame()
        {
            GameOver = true;
            DialogueHandler.PrintLine($"Congratulations! You have answered the age old question! It took {InputHandler.Character.Player.GetLicks()} licks to get to the center of yourself.");
            DialogueHandler.PrintLine("Thanks for playing! To quit out of the game, press enter.");
            Console.Read();
            DialogueHandler.PrintLine("Bye! Have a good one!");
            DialogueHandler.AddPause(600);
            Console.Clear();
        }

        /// <summary>
        /// Display fail condition text and end game
        /// Returns player to start screen
        /// </summary>
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
            DialogueHandler.PrintLine("Sorry, but your game is over. Press Enter to quit.");
        }

        /// <summary>
        /// Ends the game prematurely
        /// </summary>
        public static void QuitGame()
        {
            DialogueHandler.Print("Are you sure you want to quit the game?\nThere are no save games. You'd have to start over. Y/N: ");
            string quit = Console.ReadLine();
            if (quit.ToLower() == "y" || quit.ToLower() == "yes")
            {
                DialogueHandler.PrintLine("Bye! Thanks for playing!");
                GameOver = true;
            }
        }
    }
}
