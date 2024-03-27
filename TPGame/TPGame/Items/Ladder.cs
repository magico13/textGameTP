using TPGame.Dictionaries;
using TPGame.Handlers;
using TPGame.Models;

namespace TPGame.Items
{
    public class Ladder : Item
    {
        public Ladder() 
        {
            Name = "ladder";
        }

        public override void GetItem()
        {
            Collections.Rooms.Find(room => room.Name == "Attic").Unlock();
            DialogueHandler.PrintLine("THIS NEEDS TO BE CHANGED.");
        }
    }
}
