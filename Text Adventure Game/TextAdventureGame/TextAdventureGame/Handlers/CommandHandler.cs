using System;
using System.Collections.Generic;
using TextAdventureGame.Characters;
using TextAdventureGame.Commands;
using TextAdventureGame.MapLocations;
using TextAdventureGame.Models;
using TextAdventureGame.Items;

namespace TextAdventureGame.Handlers
{
    public static class CommandHandler
    {
        private static IRoomCommand Map = new RoomCommand();
        private static ICharacterCommand Character = new CharacterCommand();
        private static IInventoryCommand Inventory = new InventoryCommand();
        private static UserCommandHandler UserCommand = new UserCommandHandler();

        /// <summary>
        /// Displays the title, creates the map, prompts the user for a player name, and displays opnening monologue
        /// </summary>
        public static void StartGame()
        {
#if RELEASE
            Start.Title();
#endif
            InputAction action = new InputAction()
            {
                Command = "create"
            };
            Character.Execute(action);
#if RELEASE
            DialogueHandler.OpeningMonologue();
#endif
            Console.ReadKey();
            Console.Clear();
            UserCommand.Execute();
        }

        /// <summary>
        /// Handles all methods (input)
        /// (-1) Method not implemented
        /// (0) Break from loop and get new input 
        /// (1) Character Command
        /// (2) Map command
        /// (3) Inventory Command
        /// (4) Quit game
        /// </summary>
        /// <param name="input"></param>
        public static void Execute(InputAction action, int input, bool inCombat = false, string room = "")
        {
            switch (input)
            {
                case 1:
                    Character.Execute(action, inCombat);
                    break;
                case 2:
                    Map.Execute(action);
                    break;
                case 3:
                    Inventory.Execute(action, room);
                    break;
                case 4:
                    UserCommand.InCombat = inCombat;
                    break;
                case 5:
                    UserCommand.CurrentRoom = room;
                    break;
                default: //If the input is null or not yet implemented, sends the user back through the prompt
                    break;
            }
            Console.WriteLine();
        }
    }
}
