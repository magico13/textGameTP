using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TPGame.Models;

namespace TPGame.Interactables
{
    public class Computer : Item
    {
        public Computer()
        {
            Name = "Computer";
            Description = "The old girl is just as reliable as the day you got her, which is to say not very.";
            Location = "Office";
        }
    }
}

