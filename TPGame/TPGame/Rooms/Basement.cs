using TPGame.Handlers;
using TPGame.Models;

namespace TPGame.Rooms
{
    public class Basement : Room
    {
        public Basement() : base()
        {
            Name = "Basement";
            Description = "You open the door to the basement and creep down the steps.\nThe basement is pitch black. You can't see your own hands.\nThe light switch clicks uselessly." +
                          "\n...\nYou need to find a light source to explore further.";
            UsableItems = ["camping lantern"];
            Image = @"









";
        }

        public bool IsDark = true;

        public override bool RollEncounter() => !IsDark;

        public void Light() 
        {
            Image += @"
                                      |||||              |   |        
                                      |||||              |   |                             
                                      |||||              |   |                             
                              .....................______|   |         
                              |                   |          |            
                              |   ______________  |__________|
                              |   |            |  |                      
                              |   |            |  |
                              |   |            |  |                      
                              |   |____________|  |
                              |                   |                      
                              |                   |
                              |                   |                      
                              |                   |
                              .....................
";
            IsDark = false;
            string message = "In the dim light of the basement, you can see a stack of MILK CRATES and a vague silhouette.";
            Description = Description.Split("\n")[0] + "\n" + message;
            Interactables.Add("milk crates");
            InputHandler.EnterRoom(Name);
        }

        public override void DefeatBoss()
        {
            GetItems.Add("metal detector");
            GetItems.Add("shovel");
            Interactables.Add("furnace");
            Interactables.Add("water main");
            BossDefeated = true;
            string message = "The pale glow of the camping lantern illuminates the FURNACE and the WATER MAIN.\n On a wall rack, you see your METAL DETECTOR and SHOVEL.";
            DialogueHandler.PrintLine(message);
            Description = Description.Split("\n")[0] + message;
        }
    }
}
