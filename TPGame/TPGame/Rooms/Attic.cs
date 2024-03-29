using TPGame.Handlers;
using TPGame.Models;

namespace TPGame.Rooms
{
    public class Attic : Room
    {
        public Attic()
        {
            Name = "Attic";
            EncounterChance = 0.5;
            Description = "The attic hatch is open but out of reach. You see where you could hook a LADDER if you had one.";
            Interactables = ["light switch"];
            AddUsableItems();
        }

        /// <summary>
        /// Safely adds usable items that are unique to room
        /// </summary>
        private void AddUsableItems() 
        {
            UsableItems.Add("ladder");
        }

        public bool Locked = true;

        /// <summary>
        /// Adds description, image, interactables, and items as well as moving player to room to spawn boss
        /// </summary>
        public override void Unlock() 
        {
            DialogueHandler.PrintLine("You attach the ladder to the attic. The rungs creak beneath your feet as you climb.");
            Description = "THIS NEEDS TO BE CHANGED";
            Image = @"
                                    
                                 //,,&&&&&&&&&&&&&&&&,,\\                               
                            //,,&&&&&&&&&&&&&&&&&&&&&&&&&&,,\\                            
                       //,,&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&,,\\                       
                   ((,,&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&,,))                  
                  ((,,&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&,,))                 
                 ((,,&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&,,))                
                ((,,&&&&*//////////////#&&&&&&&&&&&&#\\\\\\\\\\\\\*&&&&,,))              
               ((,,&&&&&*//////////////#&&&&&&&&&&&&#\\\\\\\\\\\\\*&&&&&,,))              
              ((,,&&&&&&*//////////////#&&&&&&&&&&&&#\\\\\\\\\\\\\*&&&&&&,,))             
             ((,,&&&&&&&*//////////////#&&&&&&&&&&&&#\\\\\\\\\\\\\*&&&&&&&,,))            
            ((,,&&&&&&&&*//////////////#&&&&&&&&&&&&#\\\\\\\\\\\\\*&&&&&&&&,,))           
           ((,,&&&&&&&&&*//////////////#&&&&&&&&&&&&#\\\\\\\\\\\\\*&&&&&&&&&,,))          
          ((,,&&&&&&&&&&*//////////////#&&&&&&&&&&&&#\\\\\\\\\\\\\*&&&&&&&&&&,,))         
         ((,,&&&&&&&&&&&*//////////////#&&&&&&&&&&&&#\\\\\\\\\\\\\*&&&&&&&&&&&,,))        
        ((,,&&&&&&&&&&&&*//////////////#&&&&&&&&&&&&#\\\\\\\\\\\\\*&&&&&&&&&&&&,,))       
       ((,,&&&&&&&&&&&&&*//////////////#&&&&&&&&&&&&#\\\\\\\\\\\\\*&&&&&&&&&&&&&,,))      
    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%   
    &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&   
    &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&";
            UsableItems.Remove("ladder");
            Interactables.Add("home gym");
            InputHandler.EnterRoom(Name);
        }

        /// <summary>
        /// Spawn boss if room is accessible
        /// </summary>
        /// <returns>true if room is unlocked</returns>
        public override bool RollEncounter() => !Locked;

        /// <summary>
        /// Adds items and interactables to room
        /// </summary>
        public override void DefeatBoss()
        {
            GetItems.Add("camping lantern");
            Interactables.Add("chest");
            BossDefeated = true;
        }
    }
}
