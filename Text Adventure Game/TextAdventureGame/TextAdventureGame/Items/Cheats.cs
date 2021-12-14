using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureGame.Items
{
    public class Cheats : Item
    {
        public Cheats()
        {
            Name = "Cheats";
            Description = "Don't you like to explore and challenge yourself? No? Well, you downloaded a walkthrough from the internet. Where did you even find that?";
            Location = "Office";

        }
        public List<string> CheatsList = new List<string>();
    }
}
