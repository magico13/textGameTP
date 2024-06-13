using TPGame.Handlers;
using TPGame.Models;

namespace TPGame.Rooms
{
    public class HiddenRoom : Room
    {
        public HiddenRoom() : base()
        { 
            Name= "Hidden Room";
            Description = "The spiral staircase stretches on and on, down deeper and deeper below your house. Your feet finally find a landing on a solid concrete floor. A bright light blinds you before your eyes can adjust.";
            Interactables = ["light switch"];
            AddUsableItem();
        }

        private void AddUsableItem()
        {
            UsableItems.Add("knife");
            UsableItems.Add("shovel");
        }

        public override bool RollEncounter() => !BossDefeated;

        public override void DefeatBoss()
        {
            Interactables.Add("button");
            BossDefeated = true;
            string message = "\nYou see a BUTTON on the far wall with a sign over it that says, \n\"Evil Plan Abort Button\nDo Not Press Unless King Has Been Defeated\".";
            Description += message;
            DialogueHandler.PrintLine(message);
        }
    }
}
