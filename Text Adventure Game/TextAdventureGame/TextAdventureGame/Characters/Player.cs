using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.MapLocations;

namespace TextAdventureGame.Characters
{
    public class Player : Character
    {
        public Player() : base() 
        {
            SugarLevel = 0;
            Health = 100; //placeholder. use sugar level instead
            DamageMod = 1;
        }
        public int SugarLevel { get; set; } //if sugar level = 100, player crashes (maybe enter "sugar rush" at 100?)
    }
}
