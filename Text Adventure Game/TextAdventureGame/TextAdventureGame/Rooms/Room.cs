using System;
using System.Collections.Generic;
using TextAdventureGame.Mechanics;

namespace TextAdventureGame.MapLocations
{
    public class Room
    {
        public string Description { get; set; }
        public string Image { get; set; }
        public Room CurrentLocation { get; set; }
        public string Name { get; protected set; }
        public double EncounterChance { get; set; }
        public List<Room> MapList { get; set; }

        public List<Room> CreateMap()
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

        public Room CheckInput(string location)
        {
            foreach (Room place in MapList)
            {
                string placeString = place.Name.ToLower();

                if (placeString == location)
                {
                    if (place == CurrentLocation)
                    {
                        Room sameRoom = new Room() { Name = "" };
                        return sameRoom;
                    }

                    CurrentLocation = place;
                    return CurrentLocation;
                }
            }
            return null;
        }

        public bool RollEncounter()
        {
            bool encounter = false;
            Random encounterRandom = new Random();
            double encounterDouble = CurrentLocation.EncounterChance * encounterRandom.NextDouble();
            if (encounterDouble > 0.3)
            {
                encounter = true;
            }
            return encounter;
        }
    }
}
