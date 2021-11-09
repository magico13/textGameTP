using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureGame.Objects
{
    public class WaterBottle : Inventory
    {
        public string itemLocation = "Kitchen";

        public bool HasWater { get; private set; } = false;
        public bool KitchenFill { get; set; } = false;
        public int DrinksLeft { get; set; }

        public override bool UseItem(string use)
        {
            switch (use)
            {
                case "drink":
                    DrinksLeft--;
                    return true;

                case "fill":
                   
                    return false;

                case "nothing":
                    return true;

                default:
                    Start.PrintLine("Invalid input. Use \"Fill\" to fill with water, \"Drink\" to lower your sugar level, or \"Nothing\" to do nothing with it.");
                    return false;
            }
        }
    }
}
