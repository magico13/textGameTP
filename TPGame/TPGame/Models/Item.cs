using TPGame.Handlers;

namespace TPGame.Models
{
    public class Item
    {
        public string Name;
        public string Description;

        // <summary>
        /// Displays generic get text if not overwritten
        /// </summary>
        public virtual void GetItem() => DialogueHandler.PrintLine($"You strap the {Name} to your tool belt.");

        public virtual void GetItem(string message) => DialogueHandler.PrintLine(message);

        /// <summary>
        /// Handles item specific use functions
        /// </summary>
        public virtual void UseItem() { }

        public virtual void UseItem(string message) => DialogueHandler.PrintLine(message);
    }
}
