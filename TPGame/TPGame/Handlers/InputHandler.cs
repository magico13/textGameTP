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
        /// Checks action and redirects to appropriate command
        /// </summary>
        /// <param name="action">command and target to be redirected</param>
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
                    Hints.DisplayHints();
                    break;
                case "quit":
                    CommandHandler.GameOver = QuitGame();
                    break;
                case "search":
                    Map.SearchRoom();
                    break;

                default: //Handles unrecognized inputs
                    DialogueHandler.PrintLine("Sorry. I didn't catch that. Please try again.");
                    break;
            }
        }

        /// <summary>
        /// Lists the possible action commands
        /// </summary>
        private static void ListHelp()
        {
            foreach (KeyValuePair<string, string> item in Collections.ValidInputs)
            {
                DialogueHandler.PrintLine($"({item.Key}) {item.Value}");
            }
        }

        public static void EnterRoom(string roomName) 
        {
            DialogueHandler.PrintLine(Map.CurrentLocation.Description);
            Character.SpawnEnemy(roomName);
            Map.InCombat = true;
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
