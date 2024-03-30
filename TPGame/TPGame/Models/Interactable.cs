using TPGame.Handlers;

namespace TPGame.Models
{
    public class Interactable
    {
        public string Name = "";
        public string Description = "";

        /// <summary>
        /// Displays text indictating usable item, if there are any
        /// </summary>
        public virtual void UseInteractable() => DialogueHandler.PrintLine($"There's nothing useful you can do with the {Name}.");

        public virtual void UseInteractable(string message) => DialogueHandler.PrintLine(message);
    }
}
