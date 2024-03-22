using TPGame.Handlers;
using TPGame.Models;
using TPGame.Dictionaries;
using System.Linq;

namespace TPGame.Commands
{
    public class StuffCommand : IStuffCommand
    {
        /// <summary>
        /// Returns the description of an item
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>a
        public string CheckItem(Item target)
        {
            if (Collections.Inventory.TryGetValue(target.Name, out Item item))
            {
                return item.Description;
            }

            return $"You don't have a {target.Name.ToLower()}";
        }

        public void CheckItem(string target)
        {
            target ??= UserInput.GetString("What item do you want to check?");
            if (Collections.AllItems.ContainsKey(target) && Collections.Inventory.TryGetValue(target, out Item item))
            {
                item.CheckItem();
            }
            else
            {
                DialogueHandler.PrintLine($"You don't have a {target}");
            }
        }


        public void UseItem(string target, Room currentLocation)
        {
            target ??= UserInput.GetString("What item do you want to use?");
            if (Collections.Inventory.TryGetValue(target, out Item item))
            {
                if (currentLocation.UsableItems.Contains(target))
                {
                    item.HandleUse();
                }
                else
                {
                    DialogueHandler.PrintLine($"You can't use your {item.Name} here.");
                }
            }
            else if (Collections.AllInteractables.TryGetValue(target, out Interactable interactable))
            {
                if (currentLocation.Interactables.Contains(target))
                {
                    interactable.UseInteractable();
                }
                else
                {
                    DialogueHandler.PrintLine($"You can't find a {interactable.Name} here.");
                }
            }
            else
            {
                DialogueHandler.PrintLine($"You don't have a {target}");
            }
        }

        public void GetItem(string target, Room currentLocation)
        {
            target ??= UserInput.GetString("What item do you want to take?");
            if (Collections.AllItems.TryGetValue(target, out Item item) && currentLocation.GetItems.Contains(target))
            {
                if (Collections.Inventory.TryAdd(item.Name, item))
                {
                    item.GetItem();
                }
                else
                {
                    DialogueHandler.PrintLine($"You already have a {item.Name}");
                }

            }
            else if (Collections.AllInteractables.ContainsKey(target))
            {
                DialogueHandler.PrintLine($"You can't take the {target} with you.");
            }
            else
            {
                DialogueHandler.PrintLine($"The {currentLocation.Name.ToLower()} doesn't have a {target.ToLower()}");
            }
        }
    }
}
