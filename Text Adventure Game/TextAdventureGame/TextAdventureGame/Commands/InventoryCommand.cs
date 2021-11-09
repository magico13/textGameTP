using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.Mechanics;
using TextAdventureGame.Models;
using TextAdventureGame.Objects;

namespace TextAdventureGame.Commands
{
    public class InventoryCommand : IInventoryCommand
    {
        private Inventory Item = new Inventory();

        public void Execute(InputAction action)
        {
            switch (action.Command)
            {
                case "use":
                    UseItem(action);
                    break;
            }
        }

        private void UseItem(InputAction action)
        {
            Item = Item.CheckForItem(action.Target);
            action.Target = UserInput.GetString("What item do you want to use?");

            if (!(Item.UseItem(action.Target)))
            {
                if (Item == null || Item.Name == "")
                {
                    Start.PrintLine("Sorry, but you can't do that.");
                    Console.WriteLine();
                }
                else
                {
                    Start.PrintLine("Invalid Input. Please try again");
                }

            }
        }
    }
}
