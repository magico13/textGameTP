using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.MapLocations;
using TextAdventureGame.Mechanics;
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
        public InputAction Execute(InputAction action, bool combat = false)
        {
            switch (action.Command)
            {
                case "move":
                    return HandleMove(action, combat);
                case "view":
                    CheckMap();
                    return null;
                default:
                    return null;
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
                        Start.PrintLine("You're already there");
                        return null;
                    }
                    return place;
                }
            }
            Start.PrintLine("Sorry. That's not a place you can go right now.");
            return null;
        }

        /// <summary>
        /// Changes the current location and didsplays room information
        /// </summary>
        /// <param name="place"></param>
        private InputAction ChangeRoom(InputAction action)
        {
            Console.WriteLine($"{CurrentLocation.Image}");
            Start.PrintLine($"You are now in the {CurrentLocation.Name}");
            Start.PrintLine($"{CurrentLocation.Description}");
            Console.WriteLine();
            if (Map.RollEncounter(CurrentLocation)) //Rolls to see if a combat encounter begins
            {
                action.Command = "fight";
            }
            else
            {
                action.Command = "";
            }
            action.Target = CurrentLocation.Name;
            return action;
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
                Start.PrintLine($"{room.Name}");
            }
        }

        private InputAction HandleMove(InputAction action, bool combat = false)
        {
            if (combat)
            {
                if (UserInput.GetBool("Do you want to run? (Y/N) "))
                {
                    return null;
                }
                action.Command = "end";
            }
            else
            {
                Room place = CheckInput(action.Target); // Converts input to a location value and checks that location is viable
                if (place != null)
                {
                    CurrentLocation = place;
                    action = ChangeRoom(action);
                }
                else
                {
                    action = null;
                }
            }
            return action;
        }
    }
}
