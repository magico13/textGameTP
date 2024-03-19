using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.Commands;
using TextAdventureGame.Models;

namespace TextAdventureGame.Handlers
{
    public static class InputHandler
    {
        private readonly static ICharacterCommand Character = new CharacterCommand();
        private readonly static IRoomCommand Map = new RoomCommand();
        private readonly static InventoryCommand InventoryCommand = new InventoryCommand();

        private readonly static Dictionary<string, string> ValidInputs = new()
        {
            ["Move"] = "(Room) All done in this room? Move on to the next room, but watch out for potential tootsie pops.",
            ["Lick"] = "The only way to get to the center is to erode the candy coating. Get licking!",
            ["View"] = "This house is so big that it's easy to get lost in. View the map to see where to go next.",
            ["Check"] = "(Item) You remember that thing you picked up earlier? It might be useful. Check it out just to be sure.",
            ["Use"] = "(Item) Those items in your pack aren't just there to look pretty. Put them to good use",
            ["Get"] = "(Item) Your supplies have been scattered. You must recover them. If you come across one, use this to add it to your tool belt.",
            ["Help"] = "It helps to take time to reflect on your options. Help yourself out by stopping for a breather.",
            ["Quit"] = "Yeah, so this game doesn't have an ending yet. Quitting is not always the best option, but, for now, it's the only option."
        };

        /// <summary>
        /// Checks action command and redirects to appropriate command
        /// </summary>
        public static void HandleAction(InputAction action)
        {
            switch (action.Command)
            {
                case "lick":
                    Character.AttackEnemy(Map.CheckCombat());
                    break;
                case "move":
                    if (Map.ChangeRoom(action.Target) && Map.CheckCombat()) 
                    {
                        Character.SpawnEnemy();
                    }
                    break;
                case "view":
                    Map.ViewMap();
                    break;
                case "check":
                    InventoryCommand.CheckItem(action.Target);
                    break;
                case "use":
                    InventoryCommand.UseItem(action, Map.CurrentLocation.Name);
                    break;
                case "get":
                    InventoryCommand.GetItem(action.Target, Map.CurrentLocation.Name);
                    break;

                case "help":
                    ListHelp();
                    Console.WriteLine();
                    break;

                case "quit":
                    CommandHandler.GameOver = QuitGame();
#if RELEASE
                    if (quit)
                    {
                        Start.PrintLine($"Congratulations! You have answered the age old question! It took  licks to get to the center of yourself.");
                        Console.Read();
                    }
#endif
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
            foreach (KeyValuePair<string, string> item in ValidInputs)
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
