using TPGame.Rooms;
using TPGame.Handlers;
using TPGame.Models;
using TPGame.Dictionaries;
using System.ComponentModel.Design;

namespace TPGame.Commands
{
    public class RoomCommand
    {
        public Room CurrentLocation { get; set; } = new MasterBedroom();
        public bool InCombat { get; set; } = false;

        /// <summary>
        /// Verifies that input is a valid room
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public bool VerifyRoom(string target)
        {
            foreach (Room room in Collections.Rooms)
            {
                if (room.Name.Equals(target, System.StringComparison.CurrentCultureIgnoreCase))
                {
                    if (room.Name == CurrentLocation.Name)
                    {
                        DialogueHandler.PrintLine("You're already there");
                        return false;
                    }
                    CurrentLocation = room;
                    return true;
                }
            }
            DialogueHandler.PrintLine("Sorry. That's not a place you can go right now.");
            return false;
        }

        /// <summary>
        /// Changes the current location and didsplays room information
        /// </summary>
        /// <param name="place"></param>
        public bool ChangeRoom(string target)
        {
            if (InCombat)
            {
                if (!UserInput.GetBool("Do you want to flee combat? (Y/N) "))
                {
                    return false;
                }
            }
            if (VerifyRoom(target))
            {
                DialogueHandler.PrintCentered($"{CurrentLocation.Image}");
                DialogueHandler.PrintLine($"You are now in the {CurrentLocation.Name}");
                DialogueHandler.PrintLine($"{CurrentLocation.Description}");
                InCombat = CurrentLocation.RollEncounter(); //Rolls to see if a combat encounter begins
                CurrentLocation.HasBeenVisited = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Lists the rooms and current location
        /// </summary>
        public void ViewMap()
        {
            foreach (Room room in Collections.Rooms)
            {
                string roomName = room.Name;
                switch (room.Name)
                {
                    case "Garage":
                        if (((Garage)room).Locked)
                        {
                            roomName += " (Locked)";
                        }
                        break;
                    case "Attic":
                        if (((Attic)room).Locked)
                        {
                            roomName += " (Locked)";
                        }
                        break;
                    case "Basement":
                        if (((Basement)room).IsDark)
                        {
                            roomName += " (Dark)";
                        }
                        break;
                    default:
                        break;
                }
                if (room.Name == CurrentLocation.Name)
                {
                    roomName += " - Current Location";
                }
                DialogueHandler.PrintLine($"{roomName}");
            }
        }

        public bool CheckCombat() => InCombat;

        public void SearchRoom()
        {
            if (CurrentLocation.Name == "Pantry")
            {
                if (InCombat)
                {
                    DialogueHandler.PrintLine("You've already got trouble. Take it one at a time, cowboy.");
                }
                else
                {
                    InCombat = true;
                    InputHandler.Character.SpawnEnemy(CurrentLocation.Name);
                }
            }
            else
            {
                foreach (string i in CurrentLocation.Interactables)
                {
                    DialogueHandler.PrintLine(i);
                }
                if (CurrentLocation.Interactables.Count < 1)
                {
                    DialogueHandler.PrintLine("There's nothing you can interact with here. Try using you TOOL BELT to see if there is an item you can USE here.");
                }
            }
        }
    }
}
