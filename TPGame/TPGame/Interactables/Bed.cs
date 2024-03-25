using TPGame.Models;

namespace TPGame.Interactables
{
    public class Bed : Interactable
    {
        public Bed(string roomName) 
        {
            switch (roomName)
            {
                case "Master Bedroom":
                    Name = "master bed";
                    Description = "A cozy king-sized bed. You like your mattress firm and your pillows soft.\n" +
                        "When you're done battling lolipops, you should probably change the sheets. Clean, fresh sheets would be a nice way to celebrate.";
                    break;
                case "Guest Bedroom":
                    Name = "guest bed";
                    Description = "A modest full-sized bed. The sheets and cover are a light gray and recently changed after your family recently visited.";
                    break;
                default:
                    Description = "";
                    break;
            }   
        }
    }
}
