using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.Mechanics;

namespace TextAdventureGame.Characters
{
    public abstract class Character : GameCommand
    {
        public string Name { get; set; }
        public int DamageMod { get; set; }
        public int Health { get; set; }
        public List<Character> Characters { get; protected set; }

        public Dictionary<string, int> Healths 
        { 
            get 
            {
                Dictionary<string, int> healths = new Dictionary<string, int>();
                foreach (Character item in Characters)
                {
                    healths[item.Name] = item.Health;
                }
                return healths;
            } 
        }
        public Dictionary<string, int> DamageMods
        {
            get
            {
                Dictionary<string, int> healths = new Dictionary<string, int>();
                foreach (Character item in Characters)
                {
                    healths[item.Name] = item.DamageMod;
                }
                return healths;
            }
        }
    }
}
