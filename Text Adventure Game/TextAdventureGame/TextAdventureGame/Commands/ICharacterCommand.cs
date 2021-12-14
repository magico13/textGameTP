using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.Models;

namespace TextAdventureGame.Commands
{
    public interface ICharacterCommand
    {
        public void Execute(InputAction action, bool combat = false);
    }
}
