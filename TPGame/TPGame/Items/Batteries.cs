using TPGame.Models;

namespace TPGame.Items
{
    public class Batteries : Item
    {
        public Batteries() 
        {
            Name = "batteries";
            Description = "Four C batteries that should have enough juice to power the camping lantern for as long as you need.";
            GetLocation = "Office";
        }
    }
}
