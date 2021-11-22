using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.Models;

namespace TextAdventureGame.Commands
{
    public interface IRoomCommand
    {
        public InputAction Execute(InputAction action, bool combat = false);
    }
}
