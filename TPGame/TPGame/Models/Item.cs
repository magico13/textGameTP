using TPGame.Handlers;

namespace TPGame.Models
{
    public class Item
    {
        public string Name;
        public string GetLocation;
        public string GetError;
        public string UseLocation = "Any";
        public string Description;
        public string UseText;
        public int Uses;
        public string UsedDescription;

        public virtual void CheckItem() => DialogueHandler.PrintLine(Description);

        public virtual void GetItem(string roomName) 
        {
            DialogueHandler.PrintLine(GetLocation == roomName ? $"You strap the {Name.ToLower()} to your tool belt." : $"The {roomName.ToLower()} doesn't have a {Name.ToLower()}");
        }
        
        public void HandleUse(string roomName) 
        {
            if (UseLocation == "Any" || UseLocation == roomName)
            {
                if (Uses > 0)
                {
                    UseItem();
                    Uses --;
                    Description = Uses < 1 ? UsedDescription : Description;
                }
            }
            else
            {
                DialogueHandler.PrintLine($"You can't use the {Name.ToLower()} here");
            }
        }

        public virtual void UseItem() { }
    }
}
