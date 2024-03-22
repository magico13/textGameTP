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
            ["light switch"] = new LightSwitch(),
            ["lever"] = new EndGame(),
            ["nightstand"] = new Nightstand(),
            ["sander"] = new Sander(),
            ["sink"] = new Sink(),
            ["toilet"] = new Toilet(),
            ["tongue guard"] = new Guard(),
            ["water bowl"] = new WaterBowl(),
            ["workout equipment"] = new WorkoutEquipment()
        };

        public readonly static Dictionary<string, string> ValidInputs = new()
        {
            ["Move"] = "(Room) All done in this room? Move on to the next room, but watch out for potential tootsie pops.",
            ["Lick"] = "The only way to get to the center is to erode the candy coating. Get licking!",
            ["Map"] = "This house is so big that it's easy to get lost in. Pull out the map to see where to go next.",
            ["Check"] = "(Item) You remember that thing you picked up earlier? It might be useful. Check it out just to be sure.",
            ["Use"] = "(Item) Those items in your pack aren't just there to look pretty. Put them to good use",
            ["Get"] = "(Item) Your supplies have been scattered. You must recover them. If you come across one, use this to add it to your tool belt.",
            ["Help"] = "It helps to take time to reflect on your options. Help yourself out by stopping for a breather.",
            ["Quit"] = "Yeah, so this game doesn't have an ending yet. Quitting is not always the best option, but, for now, it's the only option.",
            ["Hint"] = "In the stress and surprise, you may have forgotten your master plan. That's fine. You can scan your mind for bits of the plan."
        };
    }
}
