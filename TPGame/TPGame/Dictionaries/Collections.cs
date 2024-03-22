using System.Collections.Generic;
using TPGame.Interactables;
using TPGame.Items;
using TPGame.MapLocations;
using TPGame.Models;
using TPGame.Rooms;

namespace TPGame.Dictionaries
{
    public static class Collections
    {
        public static readonly Room[] Rooms = [
                new Attic(),
                new Backyard(),
                new Basement(),
                new Bathroom(),
                new DiningRoom(),
                new Garage(),
                new GuestBedroom(),
                new HiddenRoom(),
                new Kitchen(),
                new LivingRoom(),
                new MasterBedroom(),
                new Office(),
                new Pantry()
            ];

        public static Dictionary<string, Item> Inventory = new Dictionary<string, Item>();

        public static readonly Dictionary<string, Item> AllItems = new()
        {
            ["batteries"] = new Batteries(),
            ["camping lantern"] = new CampingLantern(),
            ["key"] = new Key(),
            ["knife"] = new Knife(),
            ["ladder"] = new Ladder(),
            ["metal detector"] = new MetalDetector(),
            ["mints"] = new Mints(),
            ["shovel"] = new Shovel(),
            ["tool belt"] = new ToolBelt(),
            ["water bottle"] = new WaterBottle(),
        };

        public static readonly Dictionary<string, Interactable> AllInteractables = new()
        {
            ["bed"] = new Bed(),
            ["buried switch"] = new BuriedSwitch(),
            ["car"] = new Car(),
            ["chest"] = new Chest(),
            ["closet"] = new Closet(),
            ["computer"] = new Computer(),
            ["couch"] = new Couch(),
            ["craft bench"] = new CraftBench(),
            ["desk"] = new Desk(),
            ["dresser"] = new Dresser(),
            ["false teeth"] = new FalseTeeth(),
            ["fridge"] = new Fridge(),
            ["lawn mower"] = new LawnMower(),
            ["lever"] = new EndGame(),
            ["nightstand"] = new Nightstand(),
            ["sander"] = new Sander(),
            ["sink"] = new Sink(),
            ["toilet"] = new Toilet(),
            ["tongue guard"] = new Guard(),
            ["water bowl"] = new WaterBowl(),
            ["workout equipment"] = new WorkoutEquipment()
        };
    }
}
