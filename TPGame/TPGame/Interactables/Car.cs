using TPGame.Models;

namespace TPGame.Interactables
{
    public class Car : Interactable
    {
        public Car()
        {
            Name = "car";
            Description = "A car of a model that has been discontinued and a make that you're not sure ever existed. It's currently locked and you don't remember where your keys are.\n" +
                "All you can tell is that you didn't put them back on the hook. Just as well, running from this fight wouldn't solve anything.";
        }
    }
}
