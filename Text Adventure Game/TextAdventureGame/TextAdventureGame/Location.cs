using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureGame
{
    public class Location
    {
        public List<Location> Map { get; private set; }
        public string Name { get; }
        public double EncounterChance { get; }
        
        public Location(string name, double encounterChance)
        {
            Name = name;
            EncounterChance = encounterChance;
        }
        public Location() { }

        public Location StringToLocation(string location)
        {
            Location notIncluded = new Location(null, 0);
            foreach (Location place in Map)
            {
                string placeString = place.Name.ToString();

                if (placeString.ToLower() == location.ToLower())
                {
                    return place;
                }
            }
            return notIncluded;
        }
        public List<Location> CreateMap()
        {
            Location bathroom = new Location("Bathroom", 0.3);
            Location kitchen = new Location("Kitchen", 1.0);
            Location garage = new Location("Garage", 0.8);
            Map = new List<Location>();
            Map.Add(bathroom);
            Map.Add(kitchen);
            Map.Add(garage);
            return Map;
        }
    }
}
