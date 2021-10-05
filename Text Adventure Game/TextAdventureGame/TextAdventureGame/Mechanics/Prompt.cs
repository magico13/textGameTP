using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.Characters;
using TextAdventureGame.MapLocations;
using TextAdventureGame.Weapons;

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
                    if (inputSplit.Length > 1)
                    {
                        return inputSplit[1].ToLower();
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
            return location;
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
            return input;
        }
    }
}




