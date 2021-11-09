using System;
using System.Collections.Generic;
using TextAdventureGame.Models;
using TextAdventureGame.Objects;

namespace TextAdventureGame.Mechanics
{
    public static class UserInput
    {
        public static string GetString(string message)
        {
            Start.Print(message + " ");
            return Console.ReadLine();
        }

        public static InputAction GetAction()
        {
            InputAction action = new InputAction();
            Start.Print("What do you do?: ");
            string input = Console.ReadLine().ToLower();
            string[] inputSplit = input.Split(" ");
            action.Command = inputSplit[0].ToLower();
            if (inputSplit.Length > 1)
            {
                action.Target = $"{inputSplit[1].ToLower()}";
            }
            return action;
        }

        public static bool GetBool(string message)
        {
            bool validInput = false;
            while (!validInput)
            {
                Start.Print(message);
                string input = Console.ReadLine().ToLower();
                if (input == "y" || input == "yes")
                {
                    return true;
                }
                else if (input == "n" || input == "no")
                {
                    return false;
                }
                Start.Print("Invalid input. Please try again");
                Console.WriteLine();
            }
            return false;
        }
    }
}




