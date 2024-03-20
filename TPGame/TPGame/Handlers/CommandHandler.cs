using System;
using System.Collections.Generic;
using TPGame.Characters;
using TPGame.Commands;
using TPGame.MapLocations;
using TPGame.Models;
using TPGame.Items;

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
            Start.Title();
            DialogueHandler.OpeningMonologue();
#endif
            Console.ReadKey();
            Console.Clear();

            while (!GameOver)
            {
                InputHandler.HandleAction(UserInput.GetAction());
                Console.WriteLine();
            }
        }
    }
}
