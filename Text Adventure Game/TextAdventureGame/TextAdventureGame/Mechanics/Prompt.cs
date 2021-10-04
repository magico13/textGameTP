using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.Characters;
using TextAdventureGame.MapLocations;
using TextAdventureGame.Weapons;

namespace TextAdventureGame.Mechanics
{
    public class Prompt : Gameplay
    {

        public override void Execute(int input)
        {
            switch (input)
            {
                case 1:
                    //CreateCommands();
                    break;
                case 2:
                    Console.Write("Please enter a name for your character: ");
                    string name = Console.ReadLine();
                    Player.CreatePlayer(name);
                    break;
                case 3:
                    Console.Write("What do you do?: ");
                    string thingToDo = Console.ReadLine();
                    string command = StringToInput(thingToDo, 1);
                    string target = StringToInput(thingToDo, 2);
                    ActOnInput(command, target);
                    break;
                case 4:
                    string location = GetLocation();
                    Map.Execute(3, location);
                    break;
                case 5:
                    Map.Execute(1);
                    break;
            }
        }

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

        public void ActOnInput(string command, string target)
        { 
            switch (command)
            {
                case "move": //checks input for location input
                    string location = target switch
                    {
                        "" => GetLocation(),
                        null => GetLocation(),
                        _ => target,
                    };
                    Map.Execute(3, location);
                    break;

                case "lick":
                    Combat.Attack();     
                    break;

                case "help":
                    break;

                case "rooms":
                    Map.CheckMap();
                    Console.WriteLine();
                    Execute(3);
                    break;

                default:
                    Console.WriteLine("Sorry. Please try again.");
                    Console.WriteLine();
                    Execute(3);
                    break;
            }
        }

        public string GetLocation()
        {
            Console.WriteLine("Which room?");
            string location = Console.ReadLine().ToLower();
            return location;
        }

        
    }
}




