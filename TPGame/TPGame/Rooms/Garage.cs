using TPGame.Models;

namespace TPGame.MapLocations
{
    public class Garage : Room
    {
        public Garage() : base()
        {
            Name = "Garage";
            EncounterChance = 900;
            Description = "The door to the garage sticks slightly as you force it open.\nYou pull the string on the light bulb to see a messy, disorganized garage.";
            //"\nThere's an empty space where your car use to be.\nIt's in the shop for repairs.\nThe lolipops must have known you wouldn't have your car."
            Image = @"
                               &&&&&&&&&&&&&&&&&&&&&&&&&&&&&\                                       
                          &&&&&&&###########&&&##############\                                      
               &&&&&&&&&&&&&&&&&&###########&&&###############\                                     
         &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&            
        &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&(((&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&         
       &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&#&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&))       
       &&&&&&&&&&&&&& (((()))) &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& (((()))) &&&&&&&&&&))       
       &&&&&&&&&&&&& ((      )) &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& ((      )) &&&&&&&&&&&      
       &&&&&&&&&&&& ((        )) &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& ((        )) &&&&&&&&&&      
       ____________  ((      ))  _____________________________________  ((      ))  __________      
                      (((())))                                           (((())))";
        }

        public override bool RollEncounter() => true;
    }
}
