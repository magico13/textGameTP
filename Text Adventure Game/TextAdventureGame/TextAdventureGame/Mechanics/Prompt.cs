using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.Characters;
using TextAdventureGame.MapLocations;

namespace TextAdventureGame.Mechanics
{
    public class Prompt : GameCommand
    {
        public string StringToInput(string input, int ComOrTar)
        {
            string[] inputSplit = input.Split(" ");
            switch (ComOrTar)
            {
                case 1: //input is a command
                    return inputSplit[0].ToLower();
                case 2://input is a target
                    if (inputSplit.Length > 2)
                    {
                        string target = $"{inputSplit[1].ToLower()} {inputSplit[2].ToLower()}";

                        return target;
                    }
                    else if (inputSplit.Length > 1)
                    {
                        string target = $"{inputSplit[1].ToLower()}";
                        return target;
                    }
                    return "";
                default:
                    return null;
            }
        }

        public string GetLocation()
        {
            PrintLine("Which room?");
            string location = Console.ReadLine().ToLower();
            return location.ToLower();
        }

        public string GetName()
        {
            Print("Please enter a name for your character: ");
            string name = Console.ReadLine();
            return name;
        }

        public string GetAction()
        {
            Print("What do you do?: ");
            string input = Console.ReadLine();
            return input.ToLower();
        }

        public string GetItem()
        {
            Print("What item do you want to use: ");
            string input = Console.ReadLine();
            return input.ToLower();
        }

        public string GetUse()
        {
            Print("What do you want to do with it?: ");
            string input = Console.ReadLine();
            return input.ToLower();
        }
    }
}




