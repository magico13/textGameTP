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
        private InputAction Action = new InputAction();
        public bool InCombat = false;
        private bool GameOver = false;

        /// <summary>
        /// Displays the title, creates the map, prompts the user for a player name, and displays opnening monologue
        /// </summary>
        public void StartGame()
        {
#if RELEASE
            Start.Title();
#endif
            Action.Command = "create";
            Character.Execute(Action);
#if RELEASE
            DialogueHandler.OpeningMonologue();
#endif
            Console.ReadKey();
            Console.Clear();
            Action = null;
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
                Action = CheckAction();
                int input = InputHandler.GetInputFromAction(Action);
                switch (input)
                {
                    case 0: //Break from loop and get new action
                        Action = null;
                        break;
                    case 1:
                        Action = Character.Execute(Action, InCombat);
                        break;
                    case 2:
                        Action = Map.Execute(Action);
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
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Checks current action value
        /// If command is 'fight', sets InCombat to true
        /// If command is 'end', sets InCombat to false;
        /// If command is null, gets new Action from user;
        /// Else, returns Action
        /// </summary>
        /// <returns></returns>
        private InputAction CheckAction()
        {
            if (Action != null)
            {
                if (Action.Command == "fight")
                {
                    InCombat = true;
                    Action.Command = "spawn";
                }
                else if (Action.Command == "end")
                {
                    InCombat = false;
                }
            }
            else
            {
                Action = UserInput.GetAction(Action);
                Console.WriteLine();
            }
            return Action;
        }
    }
}
