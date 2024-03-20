using TPGame.Models;

namespace TPGame.Items
{
    public class Batteries : Item
    {
        public Batteries() 
        {
            Name = "Batteries";
            Description = "Four C batteries that should have enough juice to power the camping lantern for as long as you need.";
            Location = "Office";
        }
    }
}
