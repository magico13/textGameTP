using TPGame.Handlers;
using TPGame.Models;
using TPGame.Dictionaries;
using System;

namespace TPGame.Commands
{
    public class StuffCommand : IStuffCommand
    {
        public void CheckItem(string target)
        {
            target ??= UserInput.GetString("What item do you want to check?");
            Item item = Collections.VerifyItem(target);
            if (item != null)
            {
                item.CheckItem();
            }
            else
            {
                Interactable interactable = Collections.VerifyInteractable(target);
                if (interactable != null)
                {
                    interactable.CheckInteractable();
                }
                else
                {
                    DialogueHandler.PrintLine($"You don't have a {target}");
                }
            }
        }


        public void UseItem(string target, Room currentLocation)
        {
            target ??= UserInput.GetString("What item do you want to use?");
            Item item = Collections.CheckInventory(target);
            if (item != null)
            {
                if (currentLocation.UsableItems.Contains(target))
                {
                    item.UseItem();
                }
                else
                {
                    DialogueHandler.PrintLine($"You can't use your {item.Name} here.");
                }
            }
            else
            {
                Interactable interactable = Collections.VerifyInteractable(target);
                if (interactable != null)
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
            }

            DialogueHandler.PrintLine($"You don't have a {target}");
        }

        public void GetItem(string target, Room currentLocation)
        {
            target ??= UserInput.GetString("What item do you want to take?");
            Item item = Collections.VerifyItem(target);
            if (item != null)
            {
                if (currentLocation.GetItems.Contains(target))
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
                else 
                {
                    DialogueHandler.PrintLine($"The {currentLocation.Name.ToLower()} doesn't have a {target.ToLower()}");
                }
            }
            else
            {
                Interactable interactable = Collections.VerifyInteractable(target);
                if (interactable != null)
                {
                    DialogueHandler.PrintLine($"You can't take the {target} with you.");
                }
                DialogueHandler.PrintLine($"The {currentLocation.Name.ToLower()} doesn't have a {target.ToLower()}");
            }
        }
    }
}
