using TPGame.Dictionaries;
using TPGame.Models;
using TPGame.Rooms;

namespace TPGame.Items
{
    public class Ladder : Item
    {
        public Ladder()
        {
            Name = "ladder";
            Description = "The lolipop sticks surprisingly support your weight without any sign of breaking. You even fashioned convenient places to put your hands.";
        }

        public override void UseItem()
        {
            string message;
            Attic attic = (Attic)Collections.Rooms.Find(room => room.Name == "Attic");
            if (attic.Locked)
            {
                attic.Unlock();
                message = "You hook the ends of the ladder into the slots on the attic hatch. After a quick integrity check, you confidently climb into the attic.";
            }
            else 
            {
                message = "As impressed as you are by your craftmanship, you decide not to tempt fate and leave the ladder in place.";
            }
            base.UseItem(message);
        }

        public override void GetItem()
        {
            base.GetItem("You assemble the ladder and lift it proudly. Strangely, there is a spot on your tool belt to secure the ladder. Convenient.");
        }
    }
}
