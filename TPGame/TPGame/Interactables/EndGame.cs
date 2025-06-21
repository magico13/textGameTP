using System;
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
            DialogueHandler.AddPause(800);
            ConsoleColor currentBC = Console.BackgroundColor;
            ConsoleColor currentFC = Console.ForegroundColor;
            if (currentBC == ConsoleColor.Black)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
                DialogueHandler.AddPause(400);
                DialogueHandler.PrintLine("Everything goes white for a few seconds.");
                DialogueHandler.AddPause(400);
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                DialogueHandler.AddPause(400);
                DialogueHandler.PrintLine("Everything goes black for a few seconds.");
                DialogueHandler.AddPause(400);
            }
            Console.BackgroundColor = (ConsoleColor)currentBC;
            Console.ForegroundColor = (ConsoleColor)currentFC;
            Console.Clear();
            DialogueHandler.PrintLine("When it fades, you see that you are back in your yard. The dirt piles are gone. Your tool belt is gone. All of the stuff you collected is gone.");
            DialogueHandler.AddPause(400);
            DialogueHandler.PrintLine("It's over. Great job!", 20);
            CommandHandler.WinGame();
        }
    }
}
