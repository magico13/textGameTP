using System;
using System.Collections.Generic;
using System.Text;
using TPGame.Handlers;

namespace TPGame.Characters
{
    public abstract class Character
    {
        public string Name { get; set; }
        public int DamageMod { get; set; }
        public int Health { get; set; }
    }
}
