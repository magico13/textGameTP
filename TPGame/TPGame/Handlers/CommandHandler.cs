namespace TPGame.Handlers
{
    public static class CommandHandler
    {
        public static bool GameOver = false;

        /// <summary>
        /// Displays the title, creates the map, prompts the user for a player name, and displays opnening monologue
        /// </summary>
        public static void StartGame()
        {
#if RELEASE
            Start.Title();
            DialogueHandler.OpeningMonologue();
            Console.ReadKey();
            Console.Clear();
#endif

            while (!GameOver)
            {
                InputHandler.HandleAction(UserInput.GetAction());
                DialogueHandler.PrintLine("");
            }
        }
    }
}
