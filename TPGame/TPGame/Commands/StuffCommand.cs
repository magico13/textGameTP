using TPGame.Handlers;
using TPGame.Models;
using TPGame.Dictionaries;
using System.Linq;

namespace TPGame.Commands
{
    public class StuffCommand : IStuffCommand
    {
        public void CheckItem(string target)
        {
            target ??= UserInput.GetString("What item do you want to check?");
            Item item = Collections.AllItems.Find(item => item.Name.ToLower() == target);
            if (item != null)
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
            Item item = Collections.Inventory.Find(item => item.Name == target);
            Interactable interactable = Collections.AllInteractables.Find(interactable => interactable.Name.ToLower() == target);
            if (item != null)
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
            else if (interactable != null)
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
            Item item = Collections.AllItems.Find(item => item.Name == target);
            Interactable interactable = Collections.AllInteractables.Find(interactable => interactable.Name.ToLower() == target);
            if (item != null && currentLocation.GetItems.Contains(target))
            {
                if (!Collections.Inventory.Contains(item))
                {
                    item.GetItem();
                }
                else
                {
                    DialogueHandler.PrintLine($"You already have a {item.Name}");
                }

            }
            else if (interactable != null)
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
