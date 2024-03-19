using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.Handlers;

namespace TextAdventureGame.Characters
{
    public class Enemy : Character
    {
        public Enemy() : base()
        {
            Random flavorChoice = new Random();
            string flavor = Flavors[flavorChoice.Next(0, 5)];
            Name = flavor;
            Health = 10;
        }

        private List<string> Flavors { get { return new List<string>() {"cherry", "chocolate", "orange", "grape", "raspberry"}; } }
    }
}
