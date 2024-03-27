using TPGame.Handlers;
using TPGame.Models;

namespace TPGame.Rooms
{
    public class Basement : Room
    {
        public Basement() : base()
        {
            Name = "Basement";
            Description = "You open the door to the basement and creep down the steps.\nThe basement is pitch black.\nYou can't see your own hands.\nThe light switch clicks uselessly." +
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
            Description = "THIS NEEDS TO BE CHANGED";
            Interactables.Add("milk crates");
            InputAction action = new()
            {
                Command = "move",
                Target = "basement"
            };
            InputHandler.HandleAction(action);
        }

        public override void DefeatBoss()
        {
            GetItems.Add("metal detector");
            Interactables.Add("furnace");
            Interactables.Add("water main");
        }
    }
}
