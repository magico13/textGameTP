using TPGame.Handlers;

namespace TPGame.Models
{
    public class Interactable
    {
        public string Name;
        public string Description;

        public virtual void CheckInteractable() => DialogueHandler.PrintLine(Description);

        public virtual void UseInteractable() { }
    }
}
