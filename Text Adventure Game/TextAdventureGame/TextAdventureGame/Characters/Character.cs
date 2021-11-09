using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.Mechanics;

namespace TextAdventureGame.Characters
{
    public abstract class Character
    {
        public string Name { get; set; }
        public int DamageMod { get; set; }
        public int Health { get; set; }
    }
}
