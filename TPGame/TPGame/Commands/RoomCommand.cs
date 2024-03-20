using System;
using System.Collections.Generic;
using System.Text;
using TPGame.MapLocations;
using TPGame.Handlers;
using TPGame.Models;
using System.Reflection.Metadata.Ecma335;

namespace TPGame.Commands
{
    public class RoomCommand : IRoomCommand
    {
        public Room Map = new Room();
        public Room CurrentLocation { get; set; } = new MasterBedroom();
        public bool InCombat { get; set; } = false;
        private List<Room> MapList
        {
            get
            {
                List<Room> mapList = new List<Room>
            {
                new Attic(),
                new Backyard(),
                new Basement(),
                new Bathroom(),
                new DiningRoom(),
                new Garage(),
                new GuestBedroom(),
                new Kitchen(),
                new LivingRoom(),
                new MasterBedroom(),
                new Office(),
                new Pantry()
            };
                return mapList;
            }
        }

        /// <summary>
        /// Verifies that input is a valid room
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public bool VerifyRoom(string target)
        {
            foreach (Room room in MapList)
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
            foreach (Room room in MapList)
            {
                if (room.Name == CurrentLocation.Name)
                {
                    room.Name += " - Current Location";
                }
                DialogueHandler.PrintLine($"{room.Name}");
            }
        }

        public bool CheckCombat() => InCombat;
    }
}
