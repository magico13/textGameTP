using TPGame.Models;

namespace TPGame.Rooms
{
    public class HiddenRoom : Room
    {
        public HiddenRoom() : base()
        { 
            Name= "Hidden Room";
            EncounterChance = 1000;
            Description = "";
            Hidden = true;
            Interactables = ["lever"];
        }

        public override bool RollEncounter() => true;
    }
}
