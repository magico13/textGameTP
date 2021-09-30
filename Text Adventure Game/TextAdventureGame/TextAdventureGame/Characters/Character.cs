using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureGame.Characters
{
    public class Character
    {
        public string Name { get; set; }
        public int DamageMod { get; set; }
        public int Health { get; set; } = 10;
        public Character() {}

    }
}
