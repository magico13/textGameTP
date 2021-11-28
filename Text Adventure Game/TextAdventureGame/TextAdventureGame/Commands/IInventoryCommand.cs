using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.Models;

namespace TextAdventureGame.Commands
{
    public interface IInventoryCommand
    {
        public InputAction Execute(InputAction action, string roomName);
    }
}
