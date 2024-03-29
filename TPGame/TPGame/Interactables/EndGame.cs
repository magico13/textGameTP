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

        /// <summary>
        /// Ends game in victory
        /// </summary>
        public override void UseInteractable()
        {
            DialogueHandler.PrintLine("THIS NEEDS TO BE CHANGED");
            CommandHandler.WinGame();
        }
    }
}
