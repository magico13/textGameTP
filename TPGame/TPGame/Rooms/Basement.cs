using TPGame.Models;

namespace TPGame.MapLocations
{
    public class Basement : Room
    {
        public Basement() : base()
        {
            Name = "Basement";
            Description = "You open the door to the basement and creep down the steps.\nThe basement is pitch black.\nYou can't see your own hands.\nThe light switch clicks uselessly." +
                          "\n...\nYou need to find a light source to explore further.";

            Image = @"









";
        }

        private bool IsDark = true;

        public override bool RollEncounter() =>  !IsDark;

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
            
        }

        public override void DefeatBoss()
        {
            GetItems = ["metal detector"];
            Interactables = ["furnace", "water main", "milk crates"];
        }
    }
}
