using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.Models;

namespace TextAdventureGame.Handlers
{
    public static class InputHandler
    {
        /// <summary>
        /// Checks action command and redirects to appropriate command
        /// -1 = Not implemented
        /// 0 = Break from menu and get new action
        /// 1 = Character Command
        /// 2 = Room Command
        /// 3 = Inventory Command
        /// 4 = Quit Game
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static int GetInputFromAction(InputAction action)
        {
            switch (action.Command)
            {
                case "lick":
                    return 1;

                case "move":
                case "view":
                    return 2;

                case "check":
                case "use":
                case "get":
                    return 3;

                case "help":
                    ListHelp();
                    Console.WriteLine();
                    return 0;

                case "quit":
                    bool quit = QuitGame();
                    if (quit)
                    {
#if RELEASE
                        Start.PrintLine($"Congratulations! You have answered the age old question! It took  licks to get to the center of yourself.");
                        Console.Read();
#endif
                        return 4;
                    }
                    return 0;
                case "end":
                    return 0;

                default: //Handles unrecognized inputs
                    DialogueHandler.PrintLine("Sorry. Please try again.");
                    return 0;
            }
        }

        /// <summary>
        /// Lists the possible help commands
        /// </summary>
        public static void ListHelp()
        {
            Dictionary<string, string> helpDetails = new Dictionary<string, string>
            {
                ["Move"] = "(Room) All done in this room? Move on to the next room, but watch out for potential tootsie pops.",
                ["Lick"] = "The only way to get to the center is to erode the candy coating. Get licking!",
                ["View"] = "(Map) This house is so big that it's easy to get lost in. View the map to see where to go next.",
                ["Check"] = "(Item) You remember that thing you picked up earlier? It might be useful. Check it out just to be sure.",
                ["Use"] = "(Item) Those items in your pack aren't just there to look pretty. Put them to good use",
                ["Get"] = "(Item) Your supplies have been scattered. You must recover them. If you come across one, use this to add it to your tool belt.",
                ["Help"] = "It helps to take time to reflect on your options. Help yourself out by stopping for a breather.",
                ["Quit"] = "Yeah, so this game doesn't have an ending yet. Quitting is not always the best option, but, for now, it's the only option."
            };

            foreach (KeyValuePair<string, string> item in helpDetails)
            {
                DialogueHandler.PrintLine($"({item.Key}) {item.Value}");
            }
        }

        /// <summary>
        /// Ends the game prematurely
        /// </summary>
        /// <returns></returns>
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
