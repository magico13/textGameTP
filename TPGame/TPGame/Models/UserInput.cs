using System;
using TPGame.Handlers;

namespace TPGame.Models
{
    public static class UserInput
    {
        /// <summary>
        /// Prints message and prompts user for string input
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string GetString(string message)
        {
            DialogueHandler.Print(message + " ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Prompts the user for action, breaks down space seperated input
        /// First word = Command
        /// Second word = Target
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static InputAction GetAction()
        {

            DialogueHandler.Print("What do you do?: ");
            string input = Console.ReadLine().ToLower().Trim();
            string[] inputSplit = input.Split(" ");
            InputAction action = new()
            {
                Command = inputSplit[0].ToLower(),
            };
            if (inputSplit.Length > 1)
            {
                for (int i = 1; i < inputSplit.Length; i++)
                {
                    if (inputSplit[i] == "" && (action.Target == null || action.Target[i - 1] == ' '))
                    {
                        continue;
                    }

                    action.Target += inputSplit[i].ToLower() + " ";
                }
                action.Target = action.Target.Trim(' ', '\\', '|', '[', ']', '}', '\"', '\'');
         
            }
            return action;
        }

        public static InputAction GetAction(string message)
        {

            DialogueHandler.Print(message);
            string input = Console.ReadLine().ToLower().Trim();
            string[] inputSplit = input.Split(" ");
            InputAction action = new()
            {
                Command = inputSplit[0].ToLower(),
            };
            if (inputSplit.Length > 1)
            {
                for (int i = 1; i < 3 && i < inputSplit.Length; i++)
                {
                    if (action.Target[i - 1] == ' ' && inputSplit[i] == "")
                    {
                        break;
                    }
                    action.Target += inputSplit[i].ToLower() + " ";
                }
                action.Target = action.Target.Trim(' ', '\\', '|', '[', ']', '}', '\"', '\'');
            }
            return action;
        }

        /// <summary>
        /// Displays message and prompts user for yes or no repsonse
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool GetBool(string message)
        {
            bool validInput = false;
            while (!validInput)
            {
                DialogueHandler.Print(message);
                string input = Console.ReadLine().ToLower().Trim();
                if (input == "y" || input == "yes")
                {
                    return true;
                }
                else if (input == "n" || input == "no")
                {
                    return false;
                }
                DialogueHandler.PrintLine("Invalid input. Please try again");
            }
            return false;
        }
    }
}




