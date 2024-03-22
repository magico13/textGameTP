using TPGame.Handlers;
using TPGame.Models;

namespace TPGame.Interactables
{
    public class EndGame : Interactable
    {
        public EndGame() 
        {
            Name = "Mysterious Lever";
        }

        public override void UseInteractable()
        {
            CommandHandler.WinGame();
        }
    }
}
