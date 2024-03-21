using TPGame.Characters;
using TPGame.Handlers;

namespace TPGame.Commands
{
    public class CharacterCommand : ICharacterCommand
    {
        public Player Player = new Player();
        public Enemy Enemy;

        public void AttackEnemy(bool combat)
        {
            if (!combat)
            {
                DialogueHandler.PrintLine("Save your licks for the candies.");
            }
            else
            {
                Player.Licks++;
                int damage = Player.RollDamage(); //Rolls for chance to critical. Writes "Chomp" if critical
                DialogueHandler.PrintLine($"You managed to get in {damage} licks!");
                Enemy.Health -= damage; //Reduces enemy health
                Player.SugarLevel++; //Increments sugar level after every attack

                if (Enemy.Health < 1)
                {
                    DialogueHandler.PrintLine(Player.EatCandy()); //Writes end of battle text including sugar level and experience
                }

                if (Player.SugarLevel > 99)
                {
                    CommandHandler.GameOver = true;
                }
            }
        }

        public void SpawnEnemy(string roomName)
        {
            Enemy = roomName switch
            {
                "Garage" => new Enemy("Bishop"),
                "Attic" => new Enemy("Knight"),
                "Basement" => new Enemy("Rook"),
                "Hidden Room" => new Enemy("King"),
                _ => new Enemy(),
            };
            DialogueHandler.PrintLine("");
            switch (Enemy.Name) 
            {
                case "Bishop":
                case "Knight":
                case "Rook":
                    DialogueHandler.PrintLine($"Oh, no! It's the {Enemy.Name}!");
                    break;
                case "King":
                    DialogueHandler.PrintLine($"The legends are true...", 80);
                    DialogueHandler.AddPause(500);
                    DialogueHandler.PrintLine($"It's the {Enemy.Name}!");
                    break;
                default:
                    DialogueHandler.PrintLine($"Oh, no! A" + (Enemy.Name == "orange" ? "n" : "") + $" {Enemy.Name} pop has appeared!");
                    break;
            }
        }

        public void LowerSugar()
        {
            Player.SugarLevel -= 30;
            if (Player.SugarLevel < 0)
            {
                Player.SugarLevel = 0;
            }
        }
    }
}
