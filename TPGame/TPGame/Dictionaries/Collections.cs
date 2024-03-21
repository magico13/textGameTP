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
            ["tool belt"] = new ToolBelt(),
            ["key"] = new Key(),
            ["knife"] = new Knife(),
            ["metal detector"] = new MetalDetector(),
            ["shovel"] = new Shovel(),
            ["water bottle"] = new WaterBottle(),
        };

        public static readonly Dictionary<string, Interactable> AllInteractables = new()
        {
            ["computer"] = new Computer(),
            ["buried switch"] = new BuriedSwitch()
        };
    }
}
