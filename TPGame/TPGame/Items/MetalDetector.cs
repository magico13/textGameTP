using System;
using System.Collections.Generic;
using System.Text;
using TPGame.Models;

namespace TPGame.Items
{
    public class MetalDetector : Item
    {
        public MetalDetector() 
        {
            Name = "Metal Detector";
            Description = "A relatively small, relatively weak metal detector that should be plenty to find what you might need.";
            Location = "Basement";
        }
    }
}
