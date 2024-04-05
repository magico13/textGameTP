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
            Description = "The light pours in through large windows on the far side of the attic. The shine gleams off of your HOME GYM equipment that you put here after converting the guest bedroom.";
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
            Locked = false;
            InputHandler.EnterRoom(Name);
        }

        /// <summary>
        /// Spawn boss if room is accessible
        /// </summary>
        /// <returns>true if room is unlocked</returns>
        public override bool RollEncounter() => !Locked && !BossDefeated;

        /// <summary>
        /// Adds items and interactables to room
        /// </summary>
        public override void DefeatBoss()
        {
            string message = "You see the small gilded CHEST your grandmother bequeathed you, just as you left it.\nYour camping LANTERN rests on some boxes of halloween decorations.";
            DialogueHandler.PrintLine(message);
            Description += " " + message;
            GetItems.Add("lantern");
            Interactables.Add("chest");
            BossDefeated = true;
        }
    }
}
