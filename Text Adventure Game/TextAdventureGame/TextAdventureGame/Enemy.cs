using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureGame
{
    public class Enemy : Character
    {
        public Enemy(string name) : base(name)
        {
            Health = 10;
        }
    }
}
