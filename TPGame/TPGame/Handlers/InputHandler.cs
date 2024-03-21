using System;
using System.Collections.Generic;
using TPGame.Commands;
using TPGame.Models;

namespace TPGame.Handlers
{
    public static class InputHandler
    {
        private readonly static IRoomCommand Map = new RoomCommand();
        private readonly static ICharacterCommand Character = new CharacterCommand();
        private readonly static InventoryCommand InventoryCommand = new InventoryCommand();

        private readonly static Dictionary<string, string> ValidInputs = new()
        {
            ["Move"] = "(Room) All done in this room? Move on to the next room, but watch out for potential tootsie pops.",
            ["Lick"] = "The only way to get to the center is to erode the candy coating. Get licking!",
            ["Map"] = "This house is so big that it's easy to get lost in. Pull out the map to see where to go next.",
            ["Check"] = "(Item) You remember that thing you picked up earlier? It might be useful. Check it out just to be sure.",
            ["Use"] = "(Item) Those items in your pack aren't just there to look pretty. Put them to good use",
            ["Get"] = "(Item) Your supplies have been scattered. You must recover them. If you come across one, use this to add it to your tool belt.",
            ["Help"] = "It helps to take time to reflect on your options. Help yourself out by stopping for a breather.",
            ["Quit"] = "Yeah, so this game doesn't have an ending yet. Quitting is not always the best option, but, for now, it's the only option.",
            ["Hint"] = "In the stress and surprise, you may have forgotten your master plan. That's fine. You can scan your mind for bits of the plan."
        };

        /// <summary>
        /// Checks action command and redirects to appropriate command
        /// </summary>
        public static void HandleAction(InputAction action)
        {
            switch (action.Command)
            {
                case "lick":
                    Character.AttackEnemy(Map.InCombat);
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
                    InventoryCommand.CheckItem(action.Target);
                    break;
                case "use":
                    InventoryCommand.UseItem(action.Target, Map.CurrentLocation);
                    break;
                case "get":
                    InventoryCommand.GetItem(action.Target, Map.CurrentLocation);
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
