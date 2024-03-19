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

        public void AttackEnemy(bool combat)
        {
            if (!combat)
            {
                DialogueHandler.PrintLine("Save your licks for the candies.");
                Console.WriteLine();
            }
            else
            {
                Player.Licks++;
                int damage = Player.RollDamage(); //Rolls for chance to critical. Writes "Chomp" if critical
                DialogueHandler.PrintLine($"You managed to get in {damage} licks!");
                Console.WriteLine();
                Enemy.Health -= damage; //Reduces enemy health
                Player.SugarLevel++; //Increments sugar level after every attack

                if (Enemy.Health < 1)
                {
                    DialogueHandler.PrintLine(Player.EatCandy()); //Writes end of battle text including sugar level and experience
                    Console.WriteLine();
                }

                if (Player.SugarLevel > 99)
                {
                    CommandHandler.GameOver = true;
                }
            }
        }

        public void SpawnEnemy()
        {
            Enemy = new Enemy(); //Creates and names Enemy
            DialogueHandler.PrintLine($"Oh, no! A" + (Enemy.Name == "orange" ? "n" : "") + $" {Enemy.Name} pop has appeared!");
            Console.WriteLine();
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
