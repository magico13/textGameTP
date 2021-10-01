using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.Characters;

namespace TextAdventureGame.Mechanics
{
    public interface IGameplay //not implemented yet
    {
        Player PC { get; }
        Enemy Lolipop { get; }
        void Prompt(Player player);
        void Help();
    }
}
