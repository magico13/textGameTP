using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.Characters;
using TextAdventureGame.Models;

namespace TextAdventureGame.Commands
{
    public class CharacterCommand : ICharacterCommand
    {
        public Player Player = new Player();
        public Enemy Enemy = new Enemy();

        public InputAction Execute(InputAction action, bool combat = false)
        {
            switch (action.Command)
            {
                case "spawn":
                    Enemy = SpawnEnemy();
                    return null;
                case "lick":
                    if (AttackEnemy(combat)) { action = null; }
                    else { action.Command = "end"; }
                    return action;
                case "heal":
                    Player.SugarLevel = Player.LowerSugar();
                    return null;
                default:
                    return null;
            }
        }

        private bool AttackEnemy(bool combat)
        {
            if (!combat)
            {
                Start.PrintLine("Save your licks for the candies.");
                Console.WriteLine();
                return false;
            }
            else
            {
                Player.Licks = Player.Licks++;
                int damage = Player.RollDamage(); //Rolls for chance to critical. Writes "Chomp" if critical
                damage += Player.DamageMod;
                Start.PrintLine($"You managed to get in {damage} licks!");
                Console.WriteLine();
                Enemy.Health = Enemy.DamageEnemy(damage); //Reduces enemy health
                Player.SugarLevel = Player.GainSugar(); //Increments sugar level after every attack

                if (Enemy.Health < 1 || Player.SugarLevel > 99)
                {
                    Start.PrintLine(Player.EatCandy()); //Writes end of battle text including sugar level and experience
                    Console.WriteLine();
                    return false;
                }
                return true;
            }
        }

        private Enemy SpawnEnemy()
        {
            Enemy = Enemy.Spawn(); //Creates and names Enemy
            Start.PrintLine($"Oh, no! A {Enemy.Name} pop has appeared!");
            Console.WriteLine();
            return Enemy;
        }
    }
}
