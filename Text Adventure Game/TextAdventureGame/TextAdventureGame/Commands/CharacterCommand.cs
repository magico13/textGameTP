using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.Characters;
using TextAdventureGame.Handlers;
using TextAdventureGame.Models;

namespace TextAdventureGame.Commands
{
    public class CharacterCommand : ICharacterCommand
    {
        public Player Player = new Player();
        public Enemy Enemy = new Enemy();

        public void Execute(InputAction action, bool combat = false)
        {
            switch (action.Command)
            {
                case "lick":
                    if (!AttackEnemy(combat))
                    {
                        CommandHandler.Execute(action, 4, false); 
                    }
                    break;
                case "heal":
                    Player.SugarLevel = Player.LowerSugar();
                    break;
                default:
                    break;
            }
        }

        private bool AttackEnemy(bool combat)
        {
            if (!combat)
            {
                DialogueHandler.PrintLine("Save your licks for the candies.");
                Console.WriteLine();
                return false;
            }
            else
            {
                Player.Licks = Player.Licks++;
                int damage = Player.RollDamage(); //Rolls for chance to critical. Writes "Chomp" if critical
                damage += Player.DamageMod;
                DialogueHandler.PrintLine($"You managed to get in {damage} licks!");
                Console.WriteLine();
                Enemy.Health = Enemy.DamageEnemy(damage); //Reduces enemy health
                Player.SugarLevel = Player.GainSugar(); //Increments sugar level after every attack

                if (Enemy.Health < 1 || Player.SugarLevel > 99)
                {
                    DialogueHandler.PrintLine(Player.EatCandy()); //Writes end of battle text including sugar level and experience
                    Console.WriteLine();
                    return false;
                }
                return true;
            }
        }

        public void SpawnEnemy()
        {
            Enemy = Enemy.Spawn(); //Creates and names Enemy
            DialogueHandler.PrintLine($"Oh, no! A" + (Enemy.Name == "orange"?"n":"") + $" {Enemy.Name} pop has appeared!");
            Console.WriteLine();
        }
    }
}
