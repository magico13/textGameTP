using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureGame.Characters;
using TextAdventureGame.MapLocations;
using TextAdventureGame.Objects;

namespace TextAdventureGame.Mechanics
{
    public class GameCommand
    {
        public Player Player { get; set; }
        public Enemy Enemy { get; set; }
        public Combat Combat { get; set; }
        public string Target { get; set; }
        public Location Map { get; set; }
        public Prompt Prompt { get; set; }
        public bool InCombat { get; set; }
        public int Licks { get; set; } = 0;
        public Dialogue Dialogue { get; set; }
        public Items Objects { get; set; }

        /// <summary>
        /// Handles all methods (input)
        /// (1) EMPTY
        /// (2) Creates a new player
        /// (3) Takes user input and redirects it
        /// (4) Spawns enemy and starts combat
        /// (5) EMPTY
        /// (6) Checks and moves to different room and rolls for encounter
        /// (7) Damages enemy and handles end of battle if enemy or player dies
        /// </summary>
        /// <param name="input"></param>
        public virtual void Execute(int input)
        {
            switch (input)
            {
                case 1:
                    PrintLine(Objects.CheckItem(Target));
                    break;
                case 2: //Creates a player using user input as a name
                    string name = Prompt.GetName();
                    Player = Player.CreatePlayer(name);
                    break;
                case 3: //Prompts the user for an action, checks the action against a list of possible actions, and then calls the necessary method
                    string thingToDo = Prompt.GetAction(); // Prompts user for action
                    string command = Prompt.StringToInput(thingToDo, 1); //Converts first input into command
                    string target = Prompt.StringToInput(thingToDo, 2); //Checks for second input and converts it to target
                    ActOnInput(command, target); //Calls appropriate method
                    break;
                case 4: //Begins combat encounter
                    Enemy = Enemy.Spawn(); //Creates and names Enemy
                    InCombat = Combat.Encounter(); //Sets InCombat to true
                    break;
                case 5:
                    break;
                case 6: //Changes current location
                    Location place = Map.Move(Target); // Converts input to a location value and checks that location is viable
                    if (place == null)
                    {
                        break;
                    }
                    Console.WriteLine($"{place.Image}");
                    PrintLine($"You are now in the {place.Name}");
                    PrintLine($"{place.Description}");
                    Console.WriteLine();
                    bool encounter = Map.RollEncounter(place); //Rolls to see if a combat encounter begins
                    if (encounter)
                    {
                        Execute(4);
                    }
                    break;
                case 7:
                    int damage = Combat.RollDamage(); //Rolls for chance to critical. Writes "Chomp" if critical
                    damage += Player.DamageMod;
                    PrintLine($"You managed to get in {damage} licks!");
                    Console.WriteLine();
                    Enemy.Health = Enemy.DamageEnemy(damage); //Reduces enemy health
                    Player.SugarLevel = Player.GainSugar(); //Increments sugar level after every attack
                    if (Enemy.Health < 1 || Player.SugarLevel > 99) //Checks if enemy is dead or player crashes
                    {
                        InCombat = false;
                        PrintLine(Player.EatCandy()); //Writes end of battle text including sugar level and experience
                        Console.WriteLine();
                    }
                    else
                    {
                        Execute(3);
                    }
                    break;
                default: //If the input is null or not yet implemented, sends the user back through the prompt
                    Execute(3);
                    break;
            }

        }

        public void CreateCommands()
        {
            Player = new Player();
            Prompt = new Prompt();
            Enemy = new Enemy();
            Map = new Location();
            Combat = new Combat();
            Dialogue = new Dialogue();
            Objects = new Items();
        }

        public void ActOnInput(string command, string target)
        {

            switch (command)
            {
                case "move": //checks input for location input
                    bool run = false;
                    if (InCombat)
                    {
                        Print("Do you want to run away? (Y/N): ");
                        string input = Console.ReadLine();
                        if (input.ToLower() == "y" || input.ToLower() == "yes")
                        {
                            run = true;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (run)
                    {
                        InCombat = false;
                    }
                    string location;
                    switch (target)
                    {
                        case "":
                            location = Prompt.GetLocation();
                            break;
                        case null:
                            location = Prompt.GetLocation();
                            break;
                        default:
                            location = target;
                            break;
                    };
                    Target = location;
                    Execute(6); //Executes movement commands
                    break;

                case "lick": //Writes a lone of not in combat or starts damage process
                    if (InCombat)
                    {
                        Licks = Licks++;
                        Execute(7);
                        break;
                    }
                    PrintLine("Save your licks for the candies.");
                    Console.WriteLine();
                    break;

                case "help":
                    Help();
                    Console.WriteLine();
                    break;

                case "rooms": //Displays list of rooms
                    Map.CheckMap();
                    Console.WriteLine();
                    break;

                case "quit":
                    Print("Are you sure you want to quit the game?\nThere are no save games. You'd have to start over. Y/N: ");
                    string quit = Console.ReadLine();
                    if (quit.ToLower() == "y" || quit.ToLower() == "yes")
                    {
                        PrintLine("Bye! Thanks for playing!");
                        Environment.Exit(0);
                    }
                    break;

                case "check":
                    Target = target;
                    Execute(1);
                    break;

                default: //Handles unrecognized inputs
                    PrintLine("Sorry. Please try again.");
                    break;
            }
        }

        public static void PrintLine(string text, int delay = 30) //Causes text to be written at a delay simulating a typewriter effect and starts new line
        {
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(delay);
            }
            Console.WriteLine();
        }
        public static void Print(string text, int delay = 30) //Causes text to be written at a delay simulating a typewriter effect
        {
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(delay);
            }
        }

        public void Help() //Needs implementing
        {
            Dictionary<string, string> helpDetails = new Dictionary<string, string>();
            helpDetails["Move"] = "All done in this room? This will take you to another room.";
            helpDetails["Lick"] = "The only way to get to the center is to erode the candy coating. Get licking!";
            helpDetails["Rooms"] = "This house is so big that it's easy to get lost in. Use this to remember which rooms you can go to.";
            helpDetails["Check"] = "You remember that thing you picked up earlier? It might be useful. Use this to look it over one more time";
            helpDetails["Help"] = "This... Well if you need an explanation, it lists the commands that will actually do things";
            helpDetails["Quit"] = "Yeah, so this game doesn't have an ending yet. Use this if you want to stop playing for now.";

            foreach (KeyValuePair<string, string> item in helpDetails)
            {
                PrintLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
