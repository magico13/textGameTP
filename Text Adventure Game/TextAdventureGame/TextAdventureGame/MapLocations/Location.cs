using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.Mechanics;

namespace TextAdventureGame.MapLocations
{
    public class Location : GameCommand
    {
        public string Description { get; set; }
        public string Image { get; set; }
        public bool CurrentLocation { get; set; }
        
        public string Name { get; protected set; }
        
        public double EncounterChance { get; set; }

        public List<Location> MapList { get; set; }

        public List<Location> CreateMap()
        {
            List<Location> mapList = new List<Location>();
            mapList.Add(new Attic());
            mapList.Add(new Backyard());
            mapList.Add(new Basement());
            mapList.Add(new Bathroom());
            mapList.Add(new DiningRoom());
            mapList.Add(new Garage());
            mapList.Add(new GuestBedroom());
            mapList.Add(new Kitchen());
            mapList.Add(new LivingRoom());
            mapList.Add(new MasterBedroom());
            mapList.Add(new Office());
            mapList.Add(new Pantry());
            foreach (Location item in mapList)
            {
                if (item.Name == "Master Bedroom")
                {
                    item.CurrentLocation = true;
                    break;
                }
            }
            return mapList;
        }

        public Location Move(string location)
        {
            foreach (Location place in MapList)
            {
                string placeString = place.Name.ToLower();

                if (placeString == location)
                {
                    if (place.CurrentLocation)
                    {
                        PrintLine("You're already there");
                        return null;
                    }

                    foreach (Location item in MapList)
                    {
                        if (item.CurrentLocation)
                        {
                            item.CurrentLocation = false;
                        }
                    }

                    place.CurrentLocation = true;

                    return place;
                }
            }
            PrintLine("Sorry. That's not a place you can go right now.");
            return null;
        }
        

        public void CheckMap()
        {
            foreach (Location item in MapList)
            {
                PrintLine($"{item.Name} ");
            }
        }

        public bool RollEncounter(Location place)
        {
            bool encounter = false;
            Random encounterRandom = new Random();
            double encounterDouble = place.EncounterChance * encounterRandom.NextDouble();
            if (encounterDouble > 0.3)
            {
                encounter = true;
            }
            return encounter;
        }
    }
}
