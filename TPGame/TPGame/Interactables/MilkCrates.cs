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
            Description = "Plastic crates that were left here by the previous owner. You constantly debate back and forth about getting rid of them but worry they might be useful one day.";
        }

        /// <summary>
        /// Drops boss health to 0
        /// Player must still lick boss to defeat it
        /// </summary>
        public override void UseInteractable()
        {
            if (CharacterCommand.Lolipop.Health > 0)
            {
                CharacterCommand.AttackBoss("You grab one of the milk crates and vault from one to a stack of two and leap toward the knight. With a thunderous force, you smash into it's thick candy shell, thinning it significantly.");
            }
            else
            {
                base.UseInteractable("The milk crates don't seem to have much use right now.");
            }
        }
    }
}
