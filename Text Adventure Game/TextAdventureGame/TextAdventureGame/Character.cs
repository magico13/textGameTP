using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureGame
{
    public class Character
    {
        public string Name { get; }
        public int DamageMod { get; set; }
        public int Health { get; set; }
        public Character(string name, int health)
        {
            Name = name;
            Health = health;
            
        }
        public Character(string name) 
        {
            Name = name;
        }
        public Character() { }
        public Dictionary<string, int> CharacterHealths { get; set; }
        public List<Character> Characters { get; set; }


    }
}
