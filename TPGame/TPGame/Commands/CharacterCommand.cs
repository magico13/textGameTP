using TPGame.Dictionaries;
using TPGame.Handlers;
using TPGame.Models;

namespace TPGame.Commands
{
    public class CharacterCommand
    {
        public Player Player = new();
        public Enemy Lolipop = new();

        public bool AttackEnemy(bool combat)
        {
            if (!combat)
            {
                DialogueHandler.PrintLine("Save your licks for the candies.");
                return false;
            }
            else
            {
                Player.IncrementLicks();
                int damage = Player.RollDamage(); //Rolls for chance to critical. Writes "Chomp" if critical
                DialogueHandler.PrintLine($"You managed to get in {damage} licks!");
                Lolipop.Health -= damage; //Reduces enemy health
                Player.IncrementSugar(); //Increments sugar level after every attack

                if (Lolipop.Health < 1)
                {
                    Player.EatCandy(); //Writes end of battle text including sugar level and experience



                    if (Player.GetSugar() > 99)
                    {
                        CommandHandler.LoseGame();
                        return false;
                    }

                    Collections.VerifyRoom(
                            Lolipop.Name switch
                            {
                                "Bishop" => "Garage",
                                "Knight" => "Attic",
                                "Rook" => "Basement",
                                "King" => "Hidden Room",
                                _ => ""
                            })?.DefeatBoss();
                    return false;

                }
                return true;
            }
        }

        public void SpawnEnemy(string roomName)
        {
            InputHandler.Character.Lolipop = roomName switch
            {
                "Garage" => new Enemy("Bishop"),
                "Attic" => new Enemy("Knight"),
                "Basement" => new Enemy("Rook"),
                "Hidden Room" => new Enemy("King"),
                _ => new Enemy(),
            };
            DialogueHandler.PrintLine("");
            switch (InputHandler.Character.Lolipop.Name)
            {
                case "Bishop":
                case "Knight":
                case "Rook":
                    DialogueHandler.PrintLine($"Oh, no! It's the {InputHandler.Character.Lolipop.Name}!");
                    break;
                case "King":
                    DialogueHandler.PrintLine($"The legends are true...", 65);
                    DialogueHandler.AddPause(300);
                    DialogueHandler.PrintLine($"It's the {InputHandler.Character.Lolipop.Name}!", 40);
                    break;
                default:
                    DialogueHandler.PrintLine($"Oh, no! A" + (InputHandler.Character.Lolipop.Name == "orange" ? "n" : "") + $" {InputHandler.Character.Lolipop.Name} pop has appeared!");
                    break;
            }
        }

        public void AttackBoss(string message)
        {
            DialogueHandler.PrintLine(message);
            InputHandler.Character.Lolipop.Health = 0;
        }

        public string AttackKing(int damage)
        {
            if (InputHandler.Character.Lolipop.Health >= damage)
            {
                InputHandler.Character.Lolipop.Health -= damage;
                return "The king still appears daunting and stoic.";
            }
            else 
            {
                InputHandler.Character.Lolipop.Health = 0;
                return "The king is nothing but a fragile shell now.";
            }
        }
    }
}