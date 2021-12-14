using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.MapLocations;
using TextAdventureGame.Handlers;
using TextAdventureGame.Models;

namespace TextAdventureGame.Commands
{
    public class RoomCommand : IRoomCommand
    {
        public Room Map = new Room();
        public Room CurrentLocation { get; set; } = new MasterBedroom();

        /// <summary>
        /// Handles create (creates map), move (changes rooms), roll (checks for encounter), and check (displays map) commands
        /// </summary>
        /// <param name="action"></param>
        public void Execute(InputAction action, bool combat = false)
        {
            switch (action.Command)
            {
                case "move":
                    action.Command =  HandleMove(action, combat);
                    if (action.Command != "")
                    {
                        bool startCombat = action.Command == "fight"; 
                        CommandHandler.Execute(action, 5, startCombat, CurrentLocation.Name); // Changes room
                        CommandHandler.Execute(action, 4, startCombat, CurrentLocation.Name); // Start or ends combat
                    }
                    break;
                case "view":
                    CheckMap();
                    break;
                case "unlock":
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Verifies that input is a valid room
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public Room CheckInput(string location)
        {
            foreach (Room place in Map.MapList)
            {
                if (place.Name.ToLower() == location)
                {
                    if (place.Name == CurrentLocation.Name)
                    {
                        DialogueHandler.PrintLine("You're already there");
                        return null;
                    }
                    return place;
                }
            }
            DialogueHandler.PrintLine("Sorry. That's not a place you can go right now.");
            return null;
        }

        /// <summary>
        /// Changes the current location and didsplays room information
        /// </summary>
        /// <param name="place"></param>
        private string ChangeRoom()
        {
            Console.WriteLine($"{CurrentLocation.Image}");
            DialogueHandler.PrintLine($"You are now in the {CurrentLocation.Name}");
            DialogueHandler.PrintLine($"{CurrentLocation.Description}");
            Console.WriteLine();
            if (Map.RollEncounter(CurrentLocation)) //Rolls to see if a combat encounter begins
            {
                return "fight";
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Lists the rooms and current location
        /// </summary>
        private void CheckMap()
        {
            foreach (Room room in Map.MapList)
            {
                if (room.Name == CurrentLocation.Name)
                {
                    room.Name += " - Current Location";
                }
                DialogueHandler.PrintLine($"{room.Name}");
            }
        }

        private string HandleMove(InputAction action, bool combat = false)
        {
            if (combat)
            {
                if (UserInput.GetBool("Do you want to run? (Y/N) "))
                {
                    return "";
                }
                return "end";
            }
            else
            {
                Room place = CheckInput(action.Target); // Converts input to a location value and checks that location is viable
                if (place != null)
                {
                    CurrentLocation = place;
                    return ChangeRoom();
                }
                else
                {
                    return "";
                }
            }
        }
    }
}
