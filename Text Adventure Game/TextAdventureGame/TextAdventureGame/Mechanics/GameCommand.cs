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
        public Items Inventory { get; set; }
        public bool GameOver { get; set; } = false;


        public void StartGame()
        {
            Title();
            CreateCommands();
            Console.Clear();
            PrintLine($"Welcome to the world, {Player.Name}!");
            Console.WriteLine();
            PrintLine(Dialogue.OpeningMonologue);
            Console.ReadKey();
            Console.Clear();
            Execute(3);
        }

        /// <summary>
        /// Handles all methods (input)
        /// (1) Displays current inventory
        /// (2) Checks inventory for item, prompts for use command, and uses item if possible
        /// (3) Takes user input and redirects it
        /// (4) Spawns enemy and starts combat
        /// (5) EMPTY
        /// (6) Checks and moves to different room and rolls for encounter
        /// (7) Damages enemy and handles end of battle if enemy or player dies
        /// </summary>
        /// <param name="input"></param>
        public virtual void Execute(int input)
        {
            while (!GameOver)
            {
                switch (input)
                {
                    case 1: //Displays current inventory
                        if (Target == "inventory")
                        {
                            Inventory.CheckInventory();
                            break;
                        }
                        else
                        {
                            PrintLine(Inventory.CheckItem(Target));
                        }
                        break;
                    case 2: //Checks inventory for item, prompts for use command, and uses item if possible
                        Inventory = Inventory.CheckForItem(Target);
                        if (!(Inventory == null))
                        {
                            string use = Prompt.GetUse();
                            Inventory.UseItem(use);
                        }
                        else 
                        {
                            PrintLine("Invalid Input. Please try again");
                        }
                        break;
                    case 3: //Prompts the user for an action, checks the action against a list of possible actions, and then calls the necessary method
                        string thingToDo = Prompt.GetAction(); // Prompts user for action
                        string command = Prompt.StringToInput(thingToDo, 1); //Converts first input into command
                        string target = Prompt.StringToInput(thingToDo, 2); //Checks for second input and converts it to target
                        ActOnInput(command, target); //Calls appropriate method
                        break;
                    case 4: //Begins combat encounter
                        Enemy = Enemy.Spawn(); //Creates and names Enemy
                        PrintLine($"Oh, no! A {Enemy.Name} pop has appeared!");
                        Console.WriteLine();
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

                case "use":
                    string item;
                    switch (target)
                    {
                        case "":
                            item = Prompt.GetItem();
                            break;
                        case null:
                            item = Prompt.GetItem();
                            break;
                        default:
                            item = target;
                            break;
                    };
                    Target = item;
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
                        GameOver = true;
                        GameCommand.PrintLine($"Congratulations! You have answered the age old question! It took {Licks} licks to get to the center of yourself.");
                        Console.Read();
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

        public void Title()
        {
            string gameTitle = @"
                    ___   __ __    ___  _____ ______      ______   ___       ______  __ __    ___ 
                   /   \ |  |  |  /  _]/ ___/|      |    |      | /   \     |      ||  |  |  /  _]
                  |     ||  |  | /  [_(   \_ |      |    |      ||     |    |      ||  |  | /  [_ 
                  |  Q  ||  |  ||    _]\__  ||_|  |_|    |_|  |_||  O  |    |_|  |_||  _  ||    _]
                  |     ||  :  ||   [_ /  \ |  |  |        |  |  |     |      |  |  |  |  ||   [_ 
                  |     ||     ||     |\    |  |  |        |  |  |     |      |  |  |  |  ||     |
                   \__,_| \__,_||_____| \___|  |__|        |__|   \___/       |__|  |__|__||_____|
                         __    ___  ____   ______    ___  ____        ___   _____       ____         
                        /  ]  /  _]|    \ |      |  /  _]|    \      /   \ |     |     /    |        
                       /  /  /  [_ |  _  ||      | /  [_ |  D  )    |     ||   __|    |  o  |        
                      /  /  |    _]|  |  ||_|  |_||    _]|    /     |  O  ||  |_      |     |        
                     /   \_ |   [_ |  |  |  |  |  |   [_ |    \     |     ||   _]     |  _  |        
                     \     ||     ||  |  |  |  |  |     ||  .  \    |     ||  |       |  |  |        
                      \____||_____||__|__|  |__|  |_____||__|\_|     \___/ |__|       |__|__|        
                       ______   ___    ___   ______   _____ ____    ___      ____    ___   ____       
                      |      | /   \  /   \ |      | / ___/|    |  /  _]    |    \  /   \ |    \      
                      |      ||     ||     ||      |(   \_  |  |  /  [_     |  o  )|     ||  o  )     
                      |_|  |_||  O  ||  O  ||_|  |_| \__  | |  | |    _]    |   _/ |  O  ||   _/      
                        |  |  |     ||     |  |  |   /  \ | |  | |   [_     |  |   |     ||  |        
                        |  |  |     ||     |  |  |   \    | |  | |     |    |  |   |     ||  |        
                        |__|   \___/  \___/   |__|    \___||____||_____|    |__|    \___/ |__|        

";
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (gameTitle.Length / 2)) + "}", gameTitle));
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Yellow;
            string tagline1 = "How many licks does it take to get to the center of a Tootsie Pop?";
            string tagline2 = "The world may never know...";
            PrintLine(String.Format("{0," + ((Console.WindowWidth / 2) + (tagline1.Length / 2)) + "}", tagline1));
            PrintLine(String.Format("{0," + ((Console.WindowWidth / 2) + (tagline2.Length / 2)) + "}", tagline2));
            Console.WriteLine();
            string start = "Press any key to begin";
            PrintLine(String.Format("{0," + ((Console.WindowWidth / 2) + (start.Length / 2)) + "}", start));
            Console.ReadKey();
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
        }
        public void CreateCommands()
        {
            Prompt = new Prompt();
            string name = Prompt.GetName();
            Player = new Player(name);
            Enemy = new Enemy();
            Map = new Location();
            Map.MapList = Map.CreateMap();
            Combat = new Combat();
            Dialogue = new Dialogue();
            Inventory = new Items();
            Inventory.CreateItems();
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

    }
}
