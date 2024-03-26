using TPGame.Handlers;
using TPGame.Models;

namespace TPGame.Items
{
    public class FalseTeeth : Item
    {
        public FalseTeeth()
        {
            Name = "false teeth";
            Description = "A set of false teeth that look weak but may be able to give you a little more bite. +1 more bite to be exact";
        }

        public override void GetItem()
        {
            InputHandler.Character.SetCriticalThreshhold(0.5);
        }
    }
}
