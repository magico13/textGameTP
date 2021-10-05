using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.Mechanics;

namespace TextAdventureGame
{
    public class Dialogue : GameCommand
    {
        public Dialogue() { }

        public string OpeningMonologue 
        {
            get
            {
                return "You awaken to a bright new day as the sunshine pours through your window.\n\"What a beautiful day!\" you think to yourself." +
                        "\nIt's then that you hear suspicious rustling from the foot of your bed.\nAs you peer over the edge, you see wrappers strewn across your floor." +
                        "\nYou have always kept a stash of delicious Tootsie pops around,\nbut it seems they have gained sentience and are looking to get their revenge." +
                        "\nYou have trained for this moment so don't be scared.\nGather the supplies and figure out how your candies have turned so sour." +
                        "\nIt's time to be a hero...\nThe journey of any good hero starts by pushing any key to continue.";
            }
        }
    }
}
