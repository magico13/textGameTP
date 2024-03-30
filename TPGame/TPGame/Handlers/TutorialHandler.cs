using System;
using System.Threading;
using TPGame.Dictionaries;
using TPGame.Models;

namespace TPGame.Handlers
{
    public static class TutorialHandler
    {
        /// <summary>
        /// Start the game tutorial and end with player in master bedroom with tool belt
        /// </summary>
        public static void Teach()
        {
            DialogueHandler.PrintLine("Welcome! There are a preset list of commands that will work. This tutorial will highlight a few, but you an get a full list at any time by typing HELP." +
                "\nLet's begin with the basics. Type in your command and what you intend to target before pressing enter to submit you request. Be sure to check your spelling. The game is not good at guessing what you meant." +
                "\nFor example, if you want to check the MASTER BEDROOM, you would type in MOVE MASTER BEDROOM.");
            InputHandler.Map.CurrentLocation = new Models.Room();
            InputAction practiceIA = UserInput.GetAction("Go ahead try it: ");
            Collections.VerifyRoom("Master Bedroom").EncounterChance = 0;
            InputHandler.HandleAction(practiceIA);
            DialogueHandler.PrintLine("Great! You've moved to the Master Bedroom. You can also interact with items in the rooms. Keep an eye out for any capitalized words. These are either things you can interact with, rooms you can visit, or command suggestions.\n" +
                "If you forget what was in the room, you can always use SEARCH. SEARCH will show you a list of things you can interact with in the room. SEARCH doesn't require a target, the command is enough on its own.");
            practiceIA = UserInput.GetAction("Go ahead try it: ");
            InputHandler.HandleAction(practiceIA);
            DialogueHandler.PrintLine("Great! You can interact with any of these using the USE command and then whatever you want to interact with. For practice, let's USE the CLOSET.");
            practiceIA = UserInput.GetAction("Go ahead try it: ");
            InputHandler.HandleAction(practiceIA);
            DialogueHandler.PrintLine("The TOOL BELT is one of the most useful items you will find. USE will help you find items you can grab, but you have to use GET to actually take the item. Just type GET and then the item name, i.e. GET TOOL BELT.");
            practiceIA = UserInput.GetAction("Go ahead try it: ");
            InputHandler.HandleAction(practiceIA);
            DialogueHandler.PrintLine("Now that you have your TOOL BELT, you can use it at any time. While each item has its own special use, your TOOL BELT can be USEd to look at what items you have collected. The command is the same as the GET command but with USE instead of GET.\n" +
                "I won't make you do this one but keep it in mind. Sometimes, you will need to USE and item from you TOOL BELT to advance.\nKeep an eye on your sugar level and go get those lolipops! If one jumps out in front of you, you can fight it by licking it, but your sugar level will increase each time you attack. Alternatively, you can run by using MOVE and going somewhere else.\nThat's all!\n\nGOOD LUCK!");
            DialogueHandler.Print("Press any key to start the game!");
            DialogueHandler.AddPause(200);
            Console.ReadKey();
            Collections.VerifyRoom("Master Bedroom").EncounterChance = 0.6;
            Console.Clear();
        }
    }
}
