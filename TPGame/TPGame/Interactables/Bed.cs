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

        public bool Made = false;

        public override void UseInteractable()
        {
            string message;
            if (Made)
            {
                message = "Tightly made and neat as can be. You straighten the pillows slightly. You just can't quite get them right.";
            }
            else
            {
                message = "Embarassed at the sight of the unmade bed, you quickly tidy the sheets and covers. The pillows are placed meticulously, though you're not quite happy with the layout.";
                Made = true;
            }
            base.UseInteractable(message);
        }
    }
}
