using System;
using System.Collections.Generic;
using TextAdventureGame.Characters;
using TextAdventureGame.Commands;
using TextAdventureGame.MapLocations;
using TextAdventureGame.Models;
using TextAdventureGame.Items;

namespace TextAdventureGame.Handlers
{
    public class UserCommandHandler
    {
        private readonly IRoomCommand Map = new RoomCommand();
        private readonly ICharacterCommand Character = new CharacterCommand();
        private readonly IInventoryCommand Inventory = new InventoryCommand();
        private InputAction Action = new InputAction();
        public bool InCombat = false;
        public string CurrentRoom = "Master Bedroom";
        private bool GameOver = false;

        /// <summary>
        /// Handles all methods (input) 
        /// (1) Character Command
        /// (2) Map command
        /// (3) Inventory Command
        /// (4) Quit game
        /// </summary>
        /// <param name="input"></param>
        public void Execute()
        {
            while (!GameOver)
            {
                Action = UserInput.GetAction();
                Console.WriteLine(); ;
                int input = InputHandler.GetInputFromAction(Action);
                switch (input)
                {
                    case 1:
                        Character.Execute(Action, InCombat);
                        break;
                    case 2:
                        Map.Execute(Action);
                        break;
                    case 3:
                        Inventory.Execute(Action, CurrentRoom);
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
                Console.WriteLine();
            }
        }
    }
}
