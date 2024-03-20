using System;
using System.Collections.Generic;
using System.Text;

namespace TPGame.MapLocations
{
    public class GuestBedroom : Room
    {
        public GuestBedroom() : base()
        {
            Name = "Guest Bedroom";
            EncounterChance = 0.45;
            Description = "The guest bedroom is still messy from a recent guest.\nYou really need to get around to cleaning the room up.";
            Image = @"                                                                                     
              ||@@@                                                            
              ||@@@@  
              ||,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,||    
              ||,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,||     
              ||,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,||    
              ||........................................................||     
              ||                                                        ||";
        }
    }
}
