using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.Mechanics;

namespace TextAdventureGame.Weapons
{
    public class Weapon : IGameCommand
    {
        public int DamageMod { get; set; }
    }
}
