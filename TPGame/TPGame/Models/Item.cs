using TPGame.Handlers;

namespace TPGame.Models
{
    public class Item
    {
        public string Name;
        public string Description;
        public string UseText;
        public int Uses;
        public string UsedDescription;

        public virtual void CheckItem() => DialogueHandler.PrintLine(Description);

        public virtual void GetItem()
        {
            DialogueHandler.PrintLine($"You strap the {Name.ToLower()} to your tool belt.");
        }

        public void HandleUse()
        {
            if (Uses > 0)
            {
                UseItem();
                Uses--;
                Description = Uses < 1 ? UsedDescription : Description;
            }
        }

        public virtual void UseItem() { }
    }
}
