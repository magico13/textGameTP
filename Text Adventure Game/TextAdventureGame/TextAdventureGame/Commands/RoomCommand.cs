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
        private readonly Room Map = new Room();
        public bool InCombat = false;

        public void Execute(InputAction action)
        {
            switch (action.Command)
            {
                case "create":
                    Map.MapList = Map.CreateMap();
                    break;
                case "move":
                    if (InCombat)
                    {
                        bool run = UserInput.GetBool("Do you want to run? (Y/N) ");
                        if (!run)
                        {
                            break;
                        }
                        InCombat = false;
                    }
                    Room place = Map.CheckInput(action.Target); // Converts input to a location value and checks that location is viable
                    ChangeRoom(place);
                    break;
                case "roll":
                    Map.RollEncounter();
                    break; //Rolls to see if a combat encounter begins
                case "check":
                    CheckMap();
                    break;
            }
        }

        private void ChangeRoom(Room place)
        {
            if (place.Name == "")
            {
                Start.PrintLine("You're already there");
            }
            else if (place == null)
            {
                Start.PrintLine("Sorry. That's not a place you can go right now.");
            }
            else
            {
                Start.PrintLine($"{place.Image}");
                Start.PrintLine($"You are now in the {place.Name}");
                Start.PrintLine($"{place.Description}");
            }
            Console.WriteLine();
        }

        private void CheckMap()
        {
            foreach (Room room in Map.MapList)
            {
                string name = room.Name;
                if (room == Map.CurrentLocation)
                {
                    name += " - Current Location";
                }
                Start.PrintLine($"{name}");
            }
        }
    }
}
