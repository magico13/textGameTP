using System;
using System.Collections.Generic;
using TPGame.Commands;
using TPGame.Models;
using TPGame.Dictionaries;

namespace TPGame.Handlers
{
    public static class InputHandler
    {
        public readonly static RoomCommand Map = new();
        public readonly static CharacterCommand Character = new();

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
                    StuffCommand.CheckItem(action.Target);
                    break;
                case "use":
                    StuffCommand.UseItem(action.Target, Map.CurrentLocation);
                    break;
                case "get":
                    StuffCommand.GetItem(action.Target, Map.CurrentLocation);
                    break;
                case "help":
                    ListHelp();
                    break;
                case "hint":
                    Hints.DisplayHints();
                    break;
                case "quit":
                    CommandHandler.QuitGame();
                    break;
                case "search":
                    Map.SearchRoom();
                    break;
                case "sugar":
                    DialogueHandler.PrintLine($"Your sugar level is currently {Character.Player.GetSugar()}%");
                    break;
#if DEBUG
                case "gimme":
                    Cheat.PlayGameForMe();
                    break;
#endif         
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
                DialogueHandler.PrintLine($"({item.Key}) {item.Value}", 10);
            }
        }

        public static void EnterRoom(string roomName) 
        {
            DialogueHandler.PrintCentered(Map.CurrentLocation.Image);
            DialogueHandler.PrintLine(Map.CurrentLocation.Description);
            Character.SpawnEnemy(roomName);
            Map.InCombat = true;
        }
    }
}
