using TPGame.Commands;
using TPGame.Handlers;
using TPGame.Models;

namespace TPGame.Interactables
{
    public class MilkCrates : Interactable
    {
        public MilkCrates() 
        {
            Name = "milk crates";
            Description = "Plastic crates that were left here by the previous owner. You constantly debate back and forth about getting rid of them but worry they might be useful one day.\n" +
                "That day is not today.";
        }

        /// <summary>
        /// Drops boss health to 0
        /// Player must still lick boss to defeat it
        /// </summary>
        public override void UseInteractable()
        {
            if (CharacterCommand.Lolipop.Health > 0)
            {
                CharacterCommand.AttackBoss("THIS NEEDS TO BE CHANGED");
            }
            else
            {
                DialogueHandler.PrintLine("The milk crates don't seem to have much use right now.");
            }
        }
    }
}
