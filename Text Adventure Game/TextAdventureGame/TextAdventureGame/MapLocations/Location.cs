using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureGame.MapLocations
{
    public class Location
    {
        public List<Location> MapList 
        { 
            get
            {
                List<Location> mapList = new List<Location>();
                mapList.Add(new Bathroom());
                mapList.Add(new DiningRoom());
                mapList.Add(new Garage());
                mapList.Add(new Kitchen());
                mapList.Add(new LivingRoom());
                mapList.Add(new MasterBedroom());
                mapList.Add(new Office());
                mapList.Add(new Pantry());
                return mapList;
            } 
        }
        public string Name { get; protected set; }
        public double EncounterChance { get; protected set; }
        public Location[] Map 
        { 
            get 
            {
                return MapList.ToArray();
            } 
        }
        
        public Location() { }

        
        
        public Location StringToLocation(string location)
        {
            Location notIncluded = null;
            foreach (Location place in MapList)
            {
                string placeString = place.Name.ToString();

                if (placeString.ToLower() == location.ToLower())
                {
                    return place;
                }
            }
            return notIncluded;
        }
        public void CheckMap()
        {
            foreach (Location item in MapList)
            {
                Console.WriteLine($"{item.Name} ");
            }
        }
    }
}
