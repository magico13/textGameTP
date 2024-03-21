namespace TPGame.Models
{
    public class Interactable
    {
        public string Name;
        public string Description;

        public virtual void CheckInteractable() { }

        public virtual void UseInteractable() { }
    }
}
