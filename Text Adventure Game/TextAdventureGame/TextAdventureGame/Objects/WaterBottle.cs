using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureGame.Objects
{
    public class WaterBottle : Items
    {
        public string itemLocation = "Kitchen";

        public bool HasWater { get; private set; } = false;
        public bool HasBeenFilled { get; private set; } = false;
        public bool KitchenFill { get; set; } = false;
        public bool BathroomFill { get; set; } = false;

        public int DrinksLeft { get; set; }

        public override bool UseItem(string use)
        {
                switch (use)
                {
                    case "drink":
                        DrinksLeft --;
                        return true;

                    case "fill":
                        if (Map.Move("bathroom") == null)
                        {
                            if (!BathroomFill)
                            {
                                HasWater = true;
                                BathroomFill = true;
                                DrinksLeft = 5;
                                return true;
                            }
                        }
                        else if (Map.Move("kitchen") == null)
                        {
                            if (!KitchenFill)
                            {
                                HasWater = true;
                                KitchenFill = true;
                                DrinksLeft = 5;
                                return true;
                            }
                        }
                    return false;

                    case "nothing":
                        return true;

                    default:
                        PrintLine("Invalid input. Use \"Fill\" to fill with water, \"Drink\" to lower your sugar level, or \"Nothing\" to do nothing with it.");
                        return false;
                }
        }
    }
}
