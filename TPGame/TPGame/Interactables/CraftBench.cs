using TPGame.Dictionaries;
using TPGame.Handlers;
using TPGame.Models;
namespace TPGame.Interactables
{
    public class CraftBench : Interactable
    {
        public CraftBench()
        {
            Name = "craft bench";
            Description = "A sturdy workbench that has almost enough tools to make whatever you need,\nmeaning that whatever you need, you always have almost enough tools to make it.";
        }

        public override void UseInteractable()
        {
            base.UseInteractable("You scan the bench for ideas of what to make.");

            if (Collections.VerifyInventory("ladder"))
            {
                DialogueHandler.PrintLine("Nothing comes to mind based on what's scattered across the bench.");
            }
            else
            {
                if (InputHandler.Character.GetSticks() < 10)
                {
                    DialogueHandler.PrintLine("You can build a LADDER to reach the ATTIC. Except, you don't seem to have anything you could use to build it with...");
                    DialogueHandler.AddPause(200);
                    DialogueHandler.PrintLine("The LOLIPOP STICKS! They would be perfect! You need at least 10 though. That means you need " + (10 - InputHandler.Character.GetSticks()) + " more sticks.");
                }
                else
                {
                    DialogueHandler.PrintLine("You can build a LADDER to reach the ATTIC. You believe that the lolipop sticks can handle your weight with some modifications.");
                    if (Collections.VerifyInventory("knife"))
                    {
                        DialogueHandler.PrintLine("Luckily, you have your utility KNIFE that you can USE to modify the sticks.");
                    }
                    else
                    {
                        DialogueHandler.PrintLine("Unfortunately, your bench is missing something to cut the sticks");
                    }
                }
            }

        }
    }
}
