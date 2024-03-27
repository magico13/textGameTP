using TPGame.Handlers;

namespace TPGame.Models
{
    public class Item
    {
        public string Name;
        public string Description;

        public virtual void CheckItem() => DialogueHandler.PrintLine(Description);

        public virtual void GetItem()
        {
            DialogueHandler.PrintLine($"You strap the {Name.ToLower()} to your tool belt.");
        }

        public virtual void UseItem() { }
    }
}
