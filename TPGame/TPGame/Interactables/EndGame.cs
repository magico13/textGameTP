using TPGame.Handlers;
using TPGame.Models;

namespace TPGame.Interactables
{
    public class EndGame : Interactable
    {
        public EndGame() 
        {
            Name = "button";
            Description = "A mysterious button that seems to be the only thing in the room. It's glowing softly. A sign above says \"Win Game.\"";
        }

        public override void UseInteractable()
        {
            CommandHandler.WinGame();
        }
    }
}
