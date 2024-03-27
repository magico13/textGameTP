using TPGame.Handlers;

namespace TPGame.Models
{
    public class Interactable
    {
        public string Name = "";
        public string Description = "";

        public virtual void CheckInteractable() => DialogueHandler.PrintLine(Description);

        public virtual void UseInteractable() => DialogueHandler.PrintLine($"There's nothing useful you can do with the ${Name}."); 
    }
}
