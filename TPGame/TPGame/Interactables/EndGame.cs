using System;
using System.Transactions;
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
            base.UseInteractable("You approach the button reverently. The solution to all of your problems lay before you. Do you trust the sign? Is this a trap?\nYou push the button enthusiastically.");
            DialogueHandler.AddPause(600);
            Enum currentBC = Console.BackgroundColor;
            Enum currentFC = Console.ForegroundColor;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.White;
            DialogueHandler.AddPause(1000);
            Console.BackgroundColor = (ConsoleColor)currentBC;
            Console.ForegroundColor = (ConsoleColor)currentFC;
            DialogueHandler.PrintLine("Everything goes white for a few seconds. When it fades, you see that you are back in your yard. The dirt piles are gone. Your tool belt is gone. All of the stuff you collected is gone.");
            DialogueHandler.AddPause(500);
            DialogueHandler.PrintLine("It's over. Great job!", 40);
            CommandHandler.WinGame();
        }
    }
}
