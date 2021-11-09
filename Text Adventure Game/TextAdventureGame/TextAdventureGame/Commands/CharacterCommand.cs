using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.Characters;
using TextAdventureGame.Mechanics;
using TextAdventureGame.Models;

namespace TextAdventureGame.Commands
{
    public class CharacterCommand : ICharacterCommand
    {
        private Player Player = new Player("");
        private Enemy Enemy = new Enemy();
        public bool InCombat = false;

        public void Execute(InputAction action)
        {
            switch (action.Command)
            {
                case "create":
                    Player = CreatePlayer();
                    break;
                case "spawn":
                    Enemy = SpawnEnemy();
                    break;
                case "lick":
                    AttackEnemy();
                    break;
                default:
                    break;
            }
        }

        private void AttackEnemy()
        {
            if (!InCombat)
            { 
            Start.PrintLine("Save your licks for the candies.");
            Console.WriteLine();
            }
            else if (Enemy.Health > 0 || Player.SugarLevel < 100)
            {
                Player.Licks = Player.Licks++;
                int damage = Player.RollDamage(); //Rolls for chance to critical. Writes "Chomp" if critical
                damage += Player.DamageMod;
                Start.PrintLine($"You managed to get in {damage} licks!");
                Console.WriteLine();
                Enemy.Health = Enemy.DamageEnemy(damage); //Reduces enemy health
                Player.SugarLevel = Player.GainSugar(); //Increments sugar level after every attack
            }
            else
            {
                Start.PrintLine(Player.EatCandy()); //Writes end of battle text including sugar level and experience
                Console.WriteLine();
            }
        }

        private Enemy SpawnEnemy()
        {
            Enemy = Enemy.Spawn(); //Creates and names Enemy
            Start.PrintLine($"Oh, no! A {Enemy.Name} pop has appeared!");
            Console.WriteLine();
            return Enemy;
        }

        private Player CreatePlayer()
        {
            string name = UserInput.GetString("Please enter your name:");
            Player = Player.CreatePlayer(name);
            Start.PrintLine($"Welcome to the world, {Player.Name}!");
            Console.WriteLine();
            return Player;
        }
    }
}
