using System;
using System.Collections.Generic;
using TPGame.Commands;
using TPGame.Models;
using TPGame.Dictionaries;

namespace TPGame.Handlers
{
    public static class InputHandler
    {
        private readonly static IRoomCommand Map = new RoomCommand();
        public readonly static ICharacterCommand Character = new CharacterCommand();
        private readonly static IStuffCommand Stuff = new StuffCommand();

        /// <summary>
        /// Checks action command and redirects to appropriate command
        /// </summary>
        public static void HandleAction(InputAction action)
        {
            switch (action.Command)
            {
                case "lick":
                    Map.InCombat = Character.AttackEnemy(Map.InCombat);
                    break;
                case "move":
                    if (Map.ChangeRoom(action.Target) && Map.InCombat && !Map.CurrentLocation.BossDefeated) 
                    {
                        Character.SpawnEnemy(Map.CurrentLocation.Name);
                    }
                    break;
                case "map":
                    Map.ViewMap();
                    break;
                case "check":
                    Stuff.CheckItem(action.Target);
                    break;
                case "use":
                    Stuff.UseItem(action.Target, Map.CurrentLocation);
                    break;
                case "get":
                    Stuff.GetItem(action.Target, Map.CurrentLocation);
                    break;
                case "help":
                    ListHelp();
                    break;
                case "hint":
                    DialogueHandler.PrintLine("Umm...", 250);
                    DialogueHandler.AddPause(500);
                    DialogueHandler.PrintLine("I haven't actually built out the hint system yet...", 50);
                    DialogueHandler.AddPause(1000);
                    DialogueHandler.PrintLine("Sorry.", 150);
                    break;
                case "quit":
                    CommandHandler.GameOver = QuitGame();
                    break;

                default: //Handles unrecognized inputs
                    DialogueHandler.PrintLine("Sorry. Please try again.");
                    break;
            }
        }

        /// <summary>
        /// Lists the possible help commands
        /// </summary>
        private static void ListHelp()
        {
            foreach (KeyValuePair<string, string> item in Collections.ValidInputs)
            {
                DialogueHandler.PrintLine($"({item.Key}) {item.Value}");
            }
        }

        /// <summary>
        /// Ends the game prematurely
        /// </summary>
        private static bool QuitGame()
        {
            DialogueHandler.Print("Are you sure you want to quit the game?\nThere are no save games. You'd have to start over. Y/N: ");
            string quit = Console.ReadLine();
            if (quit.ToLower() == "y" || quit.ToLower() == "yes")
            {
                DialogueHandler.PrintLine("Bye! Thanks for playing!");
                return true;
            }
            return false;
        }
    }
}
