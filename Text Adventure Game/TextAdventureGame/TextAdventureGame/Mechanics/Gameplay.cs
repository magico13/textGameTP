using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.Characters;
using TextAdventureGame.MapLocations;

namespace TextAdventureGame.Mechanics
{
    public class Gameplay : GameCommand
    {
        public void Help()
        {
            Dictionary<string, string> helpDetails = new Dictionary<string, string>();
            helpDetails["Move"] = "Go to a different room";
            helpDetails["Lick"] = "I mean... I guess you could but there's nothing to lick right now so I wouldn't";
            helpDetails["Help"] = "This... Well if you need an explanation, it lists the commands that will actually do things";
            helpDetails["Rooms"] = "This house is so big that sometimes you forget how many rooms there are. This will list them all for you";

            foreach (KeyValuePair<string, string> item in helpDetails)
            {
                PrintLine($"{item.Key}: {item.Value}");
            }
            Console.WriteLine(); 
        }
    }
}
