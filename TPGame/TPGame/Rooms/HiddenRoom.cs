using TPGame.Models;

namespace TPGame.Rooms
{
    public class HiddenRoom : Room
    {
        public HiddenRoom() : base()
        { 
            Name= "Hidden Room";
            Description = "THIS NEEDS TO BE CHANGED";
            Interactables = ["light switch"];
        }

        public override bool RollEncounter() => true;

        public override void DefeatBoss()
        {
            Interactables.Add("button");
            BossDefeated = true;
        }
    }
}
