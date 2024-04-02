using TPGame.Dictionaries;
using TPGame.Handlers;
using TPGame.Models;
using TPGame.Rooms;

namespace TPGame.Items
{
    public class Mints : Item
    {
        public Mints()
        {
            Name = "mints";
            Description = "A handful of spearmint candies. The smell is powerful enough that you can smell them from your hand. You did dig these out from your couch cushions so they are covered in lint and some unidentifiable crumbs.";
        }

        private bool PlotDiscovered = false;
        public bool Eaten = false;

        public override void GetItem()
        {
            base.GetItem("You drop the mints into a safe pouch on your tool belt.");
        }

        public override void UseItem()
        {
            string message;
            HiddenRoom room = (HiddenRoom)Collections.VerifyRoom("Hidden Room");
            if (room != null && room.BossDefeated)
            {
                if (PlotDiscovered)
                {
                    Eaten = true;
                    message = "You shove the mints into your mouth, sucking and biting down as they scream and wail at their plan failing.\nThe weird voice in your head hasn't gone away yet, but you're confident that once the mints dissolve and get digested you'll return to normal.\nThe only thing to do is to USE the BUTTON and end this madness.";
                }
                else
                {
                    DialogueHandler.PrintLine("You pull out the mints to hear them chuckling maniacly. It all makes sense now.");
                    DialogueHandler.AddPause(200);
                    DialogueHandler.PrintLine("The lolipops coming to life.");
                    DialogueHandler.AddPause(200);
                    DialogueHandler.PrintLine("Your stuff being scattered everywhere.");
                    DialogueHandler.AddPause(200);
                    DialogueHandler.PrintLine("The weird voice in your head directing you to exactly where you need to go.");
                    DialogueHandler.AddPause(200);
                    DialogueHandler.PrintLine("It was the mints.");
                    DialogueHandler.AddPause(200);
                    DialogueHandler.PrintLine("They've been trapped in those cushions for too long, neglected and refreshing. They've designed this whole lolipop assault to eliminate their enemies and lead you to find them.");
                    DialogueHandler.AddPause(200);
                    DialogueHandler.PrintLine("\"You should USE the BUTTON,\" they tell you. \"Then, we will be free to carry out the final phase of our plan!\"\nThe mints take turns explaining your scheme but you can barely understand it between the other mints' crazed laughter.\nYou can push the button and admit your defeat at the hands of these mints...");
                    DialogueHandler.AddPause(400);
                    message = "Or you can teach these mints a lesson they won't soon forget.";
                    PlotDiscovered = true;
                }
            }
            else
            {
                message = "You think about popping one or two of these bad boys into the old car crusher but can't help but wonder if that long hair is yours. It's not the same color as yours. Is it even human? What else with hair that long has been sitting on\nyour couch? Better to just say no to these mints. Maybe once you've defeated the lolipops, you can have one as a celebratory snack.";
            }
            base.UseItem(message);
        }
    }
}
