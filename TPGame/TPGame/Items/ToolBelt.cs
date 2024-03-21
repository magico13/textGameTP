using TPGame.Handlers;
using TPGame.Models;

namespace TPGame.Items
{
    public class ToolBelt : Item
    {
        public ToolBelt()
        {
            Name = "tool belt";
            Description = "A modified utilty belt prepared to hold any items you find that seem useful, no matter how impratically sized.";
            // GetLocation = "Master Bedroom";
            Uses = 999;
            UsedDescription = Description;
        }

        public override void GetItem()
        {
            DialogueHandler.PrintLine("You strap your tool belt around your waist and adjust the size to acccount for your recent weight loss.");
            DialogueHandler.AddPause();
            DialogueHandler.PrintLine("You look great.");
            DialogueHandler.AddPause();
            DialogueHandler.PrintLine("You feel great.");
        }

        public override void UseItem()
        {

        }
    }
}
