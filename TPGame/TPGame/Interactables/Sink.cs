using TPGame.Models;

namespace TPGame.Interactables
{
    public class Sink : Interactable
    {
        public Sink(string roomName)
        {
            Name = "sink";
            
            switch (roomName)
            {
                case "Bathroom":
                    Description = "A sink with a mirror above it.";
                    break;
                case "Kitchen":
                    Description = "A sink with a faucet.";
                    break;
                default:
                    Name = "Sink";
                    Description = "A sink.";
                    break;
            }
        }
    }
}
