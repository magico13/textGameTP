using TextAdventureGame.Mechanics;

namespace TextAdventureGame
{
    public class Start
    {
        public static void Main(string[] args)
        {
            GameCommand Game = new GameCommand();
            //Main gameplay method
            Game.StartGame();
        }
    }
}
