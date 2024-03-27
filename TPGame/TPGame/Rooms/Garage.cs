using System.ComponentModel;
using TPGame.Models;

namespace TPGame.Rooms
{
    public class Garage : Room
    {
        public Garage() : base()
        {
            Name = "Garage";
            EncounterChance = 900;
            Description = "THIS NEEDS TO BE CHANGED";
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
            Description = "The door to the garage sticks slightly as you force it open.\nYou pull the string on the light bulb to see a messy, disorganized garage.";
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
        }

        public override void DefeatBoss() 
        {
            GetItems.Add("shovel");
            Interactables.Add("craft bench");
            Interactables.Add("car");
        }

        public override bool RollEncounter() => !Locked;
    }
}
