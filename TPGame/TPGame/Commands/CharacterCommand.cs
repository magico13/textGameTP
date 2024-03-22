using System;
using TPGame.Characters;
using TPGame.Dictionaries;
using TPGame.Handlers;
using TPGame.Models;

namespace TPGame.Commands
{
    public class CharacterCommand : ICharacterCommand
    {
        public Player Player = new Player();
        public Enemy Enemy;

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
                Enemy.Health -= damage; //Reduces enemy health
                Player.SugarLevel++; //Increments sugar level after every attack

                if (Enemy.Health < 1)
                {
                    Player.EatCandy(); //Writes end of battle text including sugar level and experience
                    Room room = Array.Find(Collections.Rooms, room => room.Name ==
                        Enemy.Name switch
                        {
                            "Bishop" => "Garage",
                            "Knight" => "Attic",
                            "Rook" => "Basement",
                            "King" => "Hidden Room",
                            _ => ""
                        });
                    if (room != null)
                    { 
                        room.BossDefeated = true;
                    }
                    return false;
                }

                if (Player.SugarLevel > 99)
                {
                    CommandHandler.GameOver = true;
                    return false;
                }
            }
            
            return true;
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

        public int GetLicks() => Player.Licks;
    }
}
