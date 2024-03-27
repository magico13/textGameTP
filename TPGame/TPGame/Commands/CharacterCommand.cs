using TPGame.Characters;
using TPGame.Dictionaries;
using TPGame.Handlers;
using TPGame.Models;

namespace TPGame.Commands
{
    public class CharacterCommand : ICharacterCommand
    {
        public Player Player = new Player();
        public static Enemy Lolipop;

        public bool AttackEnemy(bool combat)
        {
            if (!combat)
            {
                DialogueHandler.PrintLine("Save your licks for the candies.");
                return false;
            }
            else
            {
                Player.Licks++;
                int damage = Player.RollDamage(); //Rolls for chance to critical. Writes "Chomp" if critical
                DialogueHandler.PrintLine($"You managed to get in {damage} licks!");
                Lolipop.Health -= damage; //Reduces enemy health
                Player.SugarLevel++; //Increments sugar level after every attack

                if (Lolipop.Health < 1)
                {
                    Player.EatCandy(); //Writes end of battle text including sugar level and experience



                    if (Player.SugarLevel > 99)
                    {
                        CommandHandler.LoseGame();
                        return false;
                    }

                    Room room = Collections.Rooms.Find(room => room.Name ==
                            Lolipop.Name switch
                            {
                                "Bishop" => "Garage",
                                "Knight" => "Attic",
                                "Rook" => "Basement",
                                "King" => "Hidden Room",
                                _ => ""
                            });
                    if (room != null)
                    {
                        room.DefeatBoss();
                    }
                    return false;

                }
                return true;
            }
        }

        public void SpawnEnemy(string roomName)
        {
            Lolipop = roomName switch
            {
                "Garage" => new Enemy("Bishop"),
                "Attic" => new Enemy("Knight"),
                "Basement" => new Enemy("Rook"),
                "Hidden Room" => new Enemy("King"),
                _ => new Enemy(),
            };
            DialogueHandler.PrintLine("");
            switch (Lolipop.Name)
            {
                case "Bishop":
                case "Knight":
                case "Rook":
                    DialogueHandler.PrintLine($"Oh, no! It's the {Lolipop.Name}!");
                    break;
                case "King":
                    DialogueHandler.PrintLine($"The legends are true...", 80);
                    DialogueHandler.AddPause(500);
                    DialogueHandler.PrintLine($"It's the {Lolipop.Name}!");
                    break;
                default:
                    DialogueHandler.PrintLine($"Oh, no! A" + (Lolipop.Name == "orange" ? "n" : "") + $" {Lolipop.Name} pop has appeared!");
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

        public int GetLicks() => Player.Licks;

        public static void AttackBoss(string message)
        {
            DialogueHandler.PrintLine(message);
            Lolipop.Health = 0;
        }

        public void SetCriticalThreshhold(double crit) => Player.CriticalThreshhold = crit;
    }
}