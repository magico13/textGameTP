using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.Mechanics;

namespace TextAdventureGame.MapLocations
{
    public class Location : GameCommand
    {
        public bool CurrentLocation { get; set; }
        
        public string Name { get; protected set; }
        
        public double EncounterChance { get; set; }

        public List<Location> MapList { get; set; }

        public void Execute(int input, string target)
        {
            switch (input)
            {
                case 1:
                    CreateMap();
                    break;
                case 2:
                    CheckMap();
                    break;
                case 3:
                    Location place = StringToLocation(target);
                    Move(place);
                    bool encounter = RollEncounter(place);
                    if (encounter)
                    {
                        base.Execute(1);
                    }
                    base.Execute(2);
                    break;
            }
        }

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

        public Location StringToLocation(string location)
        {
            foreach (Location place in MapList)
            {
                string placeString = place.Name.ToLower();
                
                if (placeString == location)
                {
                    if (place.CurrentLocation)
                    {
                        return new Location() { Name = "same" };
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
           return null;
        }

        public void CheckMap()
        {
            foreach (Location item in MapList)
            {
                Console.WriteLine($"{item.Name} ");
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

        public void Move(Location place)
        {
            if (place == null)
            {
                Console.WriteLine("Sorry. That's not a place you can go right now.");
                //Prompt.Execute(3);
            }
            else if (place.Name == "same")
            {
                Console.WriteLine("You're already there");
                Prompt.Execute(3);
            }
        }

        public override void Execute(int input)
        {
        }
    }
}
