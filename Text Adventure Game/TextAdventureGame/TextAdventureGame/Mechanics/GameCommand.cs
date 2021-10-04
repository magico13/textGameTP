using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.Characters;
using TextAdventureGame.MapLocations;

namespace TextAdventureGame.Mechanics
{
    public class GameCommand : IGameCommand
    {
        public Player Player { get; set; }

        public Enemy Enemy { get; set; }

        public Combat Combat { get; set; }

        public Location Map { get; set; }

        public Prompt Prompt { get; set; }

        public List<int> Entries { get; }

        public virtual void Execute(int input) 
        {
            switch (input)
            {
                case 1:
                Combat.Encounter();
                    break;
                case 2:
                    Prompt.Execute(3);
                    break;
                case 3:
                    Prompt.Execute(2);
                    break;
                default:
                    break;
            }
            
        }

        public void CreateCommands()
        {
            Player = new Player();
            Prompt = new Prompt();
            Enemy = new Enemy();
            Map = new Location();
            Combat = new Combat();

        }
    }
}
