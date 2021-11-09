using System;
using System.Collections.Generic;
using TextAdventureGame.Characters;
using TextAdventureGame.Commands;
using TextAdventureGame.MapLocations;
using TextAdventureGame.Models;
using TextAdventureGame.Objects;

namespace TextAdventureGame.Mechanics
{
    public class CommandHandler
    {
        private readonly IRoomCommand Map = new RoomCommand();
        private readonly ICharacterCommand Character = new CharacterCommand();
        private readonly IInventoryCommand Inventory = new InventoryCommand();
        private InputAction Action = new InputAction() { Command = "create" };
        private bool GameOver = false;

        public void StartGame()
        {
            Start.Title();
            Map.Execute(Action);
            Character.Execute(Action);
            DialogueHandler.OpeningMonologue();
            Console.ReadKey();
            Console.Clear();
            Execute();
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
        private void Execute()
        {
            while (!GameOver)
            {
                Action = UserInput.GetAction();
                int input = InputHandler.GetInputFromAction(Action);
                switch (input)
                {
                    case 0: //Break from loop and get new action
                        break;
                    case 1:
                        Character.Execute(Action);
                        break;
                    case 2:
                        Map.Execute(Action);
                        break;
                    case 3:
                        Inventory.Execute(Action);
                        break;
                    case 4:
                        GameOver = true;
                        break;
                    case -1:
                        Console.WriteLine("That hasn't been implemented yet");
                        break;
                    default: //If the input is null or not yet implemented, sends the user back through the prompt
                        break;
                }
            }

        }
    }
}
