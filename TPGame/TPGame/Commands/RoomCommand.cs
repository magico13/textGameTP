using TPGame.MapLocations;
using TPGame.Handlers;
using TPGame.Models;
using TPGame.Dictionaries;

namespace TPGame.Commands
{
    public class RoomCommand : IRoomCommand
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
                if (room.Name.ToLower() == target)
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
                if (!UserInput.GetBool("Do you want to run? (Y/N) "))
                {
                    InCombat = false;
                    return false;
                }
            }
            if (VerifyRoom(target))
            {
                DialogueHandler.PrintLine($"{CurrentLocation.Image}", 0);
                DialogueHandler.PrintLine($"You are now in the {CurrentLocation.Name}");
                DialogueHandler.PrintLine($"{CurrentLocation.Description}");
                InCombat = CurrentLocation.RollEncounter(); //Rolls to see if a combat encounter begins
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
                if (!room.Hidden)
                {
                    if (room.Name == CurrentLocation.Name)
                    {
                        room.Name += " - Current Location";
                    }
                    DialogueHandler.PrintLine($"{room.Name}");
                }
            }
        }

        public bool CheckCombat() => InCombat;
    }
}
