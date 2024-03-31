using TPGame.Handlers;
using TPGame.Models;
using TPGame.Dictionaries;
using TPGame.Rooms;

namespace TPGame.Commands
{
    public class StuffCommand : IStuffCommand
    {
        /// <summary>
        /// Verifies target and item before displaying item description
        /// </summary>
        /// <param name="target"></param>
        public void CheckItem(string target)
        {
            target ??= UserInput.GetString("What item do you want to check?");
            Item item = Collections.CheckInventory(target);
            if (item != null)
            {
                DialogueHandler.PrintLine(item.Description);
            }
            else
            {
                if (target == "bed")
                {
                    target = InputHandler.Map.CurrentLocation.Name.ToLower().Split(" ")[0] + " " + target;
                }
                if (target == "sink")
                {
                    target = InputHandler.Map.CurrentLocation.Name.ToLower() + " " + target;
                }
                Interactable interactable = Collections.VerifyInteractable(target);
                if (interactable != null && InputHandler.Map.CurrentLocation.Interactables.Contains(target))
                {
                    DialogueHandler.PrintLine(interactable.Description);
                }
                else
                {
                    DialogueHandler.PrintLine($"You don't have a {target}.");
                }
            }
        }

        /// <summary>
        /// Verifies input and checks usability of item before completing items use function
        /// </summary>
        /// <param name="target">action target</param>
        /// <param name="currentLocation">room item is being used</param>
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
                else if ((InputHandler.Map.CurrentLocation.Name == "Garage" && ((Garage)InputHandler.Map.CurrentLocation).Locked) || (InputHandler.Map.CurrentLocation.Name == "Attic" && ((Attic)InputHandler.Map.CurrentLocation).Locked))
                {
                    DialogueHandler.PrintLine("You need to get in the room first.");
                }
                else if (InputHandler.Map.CurrentLocation.Name == "Basement" && ((Basement)InputHandler.Map.CurrentLocation).IsDark)
                {
                    DialogueHandler.PrintLine("It's too dark to see anything. You need to find a light source.");
                }
                else
                {
                    DialogueHandler.PrintLine($"You can't use your {item.Name} here.");
                }
            }
            else
            {
                if (target == "bed")
                {
                    target = InputHandler.Map.CurrentLocation.Name.ToLower().Split(" ")[0] + " " + target;
                }
                if (target == "sink")
                {
                    target = InputHandler.Map.CurrentLocation.Name.ToLower() + " " + target;
                }
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
                else
                {
                    DialogueHandler.PrintLine($"You don't have a {target}.");
                }
            }
        }

        /// <summary>
        /// Verifies input and item availibility before adding item to inventory
        /// </summary>
        /// <param name="target"></param>
        /// <param name="currentLocation"></param>
        public void GetItem(string target, Room currentLocation)
        {
            target ??= UserInput.GetString("What item do you want to take?");
            Item item = Collections.VerifyItem(target);
            if (item != null)
            {
                if (currentLocation.GetItems.Contains(item.Name))
                {
                    if (item.Name == "tool belt" || Collections.VerifyInventory("tool belt") || item.Name == "hints")
                    {
                        item.GetItem();
                        Collections.Inventory.Add(item);
                        currentLocation.GetItems.Remove(item.Name);
                    }
                    else
                    {
                        DialogueHandler.PrintLine("You forgot to get your tool belt. Without it, you won't be able to manage all of the stuuf you need.");
                    }
                }
                else if (Collections.VerifyInventory(item.Name))
                {
                    DialogueHandler.PrintLine($"You already have a {item.Name}.");
                }
                else if ((InputHandler.Map.CurrentLocation.Name == "Garage" &&  ((Garage)InputHandler.Map.CurrentLocation).Locked) || (InputHandler.Map.CurrentLocation.Name == "Attic" && ((Attic)InputHandler.Map.CurrentLocation).Locked))
                {
                    DialogueHandler.PrintLine("You need to get in the room first.");
                }
                else if (InputHandler.Map.CurrentLocation.Name == "Basement" && ((Basement)InputHandler.Map.CurrentLocation).IsDark)
                {
                    DialogueHandler.PrintLine("It's too dark to see anything. You need to find a light source.");
                }
                else
                {
                    DialogueHandler.PrintLine($"The {currentLocation.Name.ToLower()} doesn't have a {item.Name}.");
                }
            }
            else
            {
                if (target == "bed")
                {
                    target = InputHandler.Map.CurrentLocation.Name.ToLower().Split(" ")[0] + " " + target;
                }
                if (target == "sink")
                {
                    target = InputHandler.Map.CurrentLocation.Name.ToLower() + " " + target;
                }
                Interactable interactable = Collections.VerifyInteractable(target);
                if (interactable != null)
                {
                    DialogueHandler.PrintLine($"You can't take the {interactable.Name} with you.");
                }
                DialogueHandler.PrintLine($"The {currentLocation.Name.ToLower()} doesn't have a {target.ToLower()}.");
            }
        }
    }
}
