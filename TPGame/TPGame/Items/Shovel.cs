using System;
using System.Collections.Generic;
using System.Text;
using TPGame.Models;

namespace TPGame.Items
{
    public class Shovel : Item
    {
        public Shovel() 
        {
            Name = "shovel";
            Description = "This line left intentionally blank";
            GetLocation = "Garage";
        }
    }
}
