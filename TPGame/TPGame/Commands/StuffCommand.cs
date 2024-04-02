using TPGame.Handlers;
using TPGame.Models;
using TPGame.Dictionaries;
using TPGame.Rooms;

namespace TPGame.Commands
{
    public static class StuffCommand
    {
        /// <summary>
        /// Verifies target and item before displaying item description
        /// </summary>
        /// <param name="target"></param>
        public static void CheckItem(string target)
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
                    DialogueHandler.PrintLine($"You don't have {(target.EndsWith('s') ? "any" : "a")} {target}.");
                }
            }
        }

        /// <summary>
        /// Verifies input and checks usability of item before completing items use function
        /// </summary>
        /// <param name="target">action target</param>
        /// <param name="currentLocation">room item is being used</param>
        public static void UseItem(string target, Room currentLocation)
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
                    DialogueHandler.PrintLine($"You don't have {(target.EndsWith('s') ? "any" : "a")} {target}.");
                }
            }
        }

        /// <summary>
        /// Verifies input and item availibility before adding item to inventory
        /// </summary>
        /// <param name="target"></param>
        /// <param name="currentLocation"></param>
        public static void GetItem(string target, Room currentLocation)
        {
            target ??= UserInput.GetString("What item do you want to take?");
            Item item = Collections.VerifyItem(target);
            if (item != null)
            {
                if (currentLocation.GetItems.Contains(item.Name))
                {
                    if (!Collections.VerifyInventory("tool belt"))
                    {
                        if (item.Name == "tool belt" || (item.Name == "hints" && !Collections.VerifyInventory("hints")))
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
                    else
                    {
                        if (item.Name == "hints" && Collections.VerifyInventory("hints"))
                        {
                            DialogueHandler.PrintLine("You already have all of the help I can give you. If you forget the commands, use HELP. If you just wanted one hint, just type HINT. No need for USE or CHECK.");
                        }
                        else
                        {
                            item.GetItem();
                            Collections.Inventory.Add(item);
                            currentLocation.GetItems.Remove(item.Name);
                        }
                    }
                }
                else if (Collections.VerifyInventory(item.Name))
                {
                    DialogueHandler.PrintLine($"You already have {(item.Name.EndsWith('s') ? "" : "a ")}{item.Name}.");
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
                    DialogueHandler.PrintLine($"The {currentLocation.Name.ToLower()} doesn't have {(item.Name.EndsWith('s') ? "any" : "a")} {item.Name}.");
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
                    string message = interactable.Name switch
                    {
                        "towel" => "It's sweaty and gross. Just leave it here to dry.",
                        "candles" => "You think about grabbing them, but then you'd have to reset them, and, if you burn one, they'll be uneven. It's just not worth it.",
                        "chair" => "There's weirdly no strap on your tool belt for the chair. You can fit some wild stuff on your belt so this must mean that you don't need it for the plan.",
                        "home gym" => "If you take it out of here, it will just sit around wherever you move it to until you eventually bring it back. Best to just leave it.",
                        "sander" => "It's been through enough taking out the bishop. It doesn't seem like it would do much more from here anyway.",
                        "chest" => "You can't even open it yet. Best to just leave it be.",
                        _ => $"You can't take the {interactable.Name} with you."
                    };
                    DialogueHandler.PrintLine(message);
                }
                else
                {
                    DialogueHandler.PrintLine($"The {currentLocation.Name.ToLower()} doesn't have {(target.EndsWith('s') ? "any" : "a")} {target.ToLower()}.");
                }
            }
        }
    }
}
