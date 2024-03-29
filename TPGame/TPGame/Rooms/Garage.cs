using TPGame.Handlers;
using TPGame.Models;

namespace TPGame.Rooms
{
    public class Garage : Room
    {
        public Garage() : base()
        {
            Name = "Garage";
            EncounterChance = 900;
            Description = "You turn the knob to discover that the door is locked. No matter how hard you press against the door, while trying to not break it down (you still have to live here after all), you can't seem to get in. You need to find the KEY.";
            Image = "";
            AddUsableItem();
        }

        private void AddUsableItem()
        {
            UsableItems.Add("key");
        }

        public bool Locked = true;

        public override void Unlock()
        {
            Locked = false;
            Description = "The door to the garage sticks slightly as you force it open. You pull the string on the light bulb to see a messy, disorganized garage.";
            Interactables = ["light switch", "sander"];
            Image = @"
                               &&&&&&&&&&&&&&&&&&&&&&&&&&&&&\                                       
                          &&&&&&&###########&&&##############\                                      
               &&&&&&&&&&&&&&&&&&###########&&&###############\                                     
         &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&            
        &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&(((&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&         
       &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&#&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&))       
       &&&&&&&&&&&&&& (((()))) &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& (((()))) &&&&&&&&&&))       
       &&&&&&&&&&&&& ((      )) &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& ((      )) &&&&&&&&&&&      
       &&&&&&&&&&&& ((        )) &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& ((        )) &&&&&&&&&&      
       ____________  ((      ))  _____________________________________  ((      ))  __________      
                      (((())))                                           (((())))";

            Description += "\nYou see your CAR and a CRAFT BENCH you can't reach because of the bishop. The belt SANDER, however, is near your leg and looks plugged in.";
            InputHandler.EnterRoom(Name);
        }

        public override void DefeatBoss() 
        {
            Description = Description.Split("\n")[0] + "\nAs you look around, you can see your CAR parked where you left it and a CRAFT BENCH set up against the far wall";
            Interactables.Add("craft bench");
            Interactables.Add("car");
            UsableItems.Add("knife");
            BossDefeated = true;
        }

        public override bool RollEncounter() => !Locked;
    }
}
