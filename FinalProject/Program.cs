using System;
using System.IO;

//class = Adventure Game
class AdventureGame
{
    struct Player
    {
        public string Name;
        public bool IsAlive;
    }
     //MAin function which contains the while loop and also inquiring player name
    static void Main()
    {   
        //inquire player's name
        Console.Write("Enter your name: ");
        //stores player's name
        string playerName = Console.ReadLine();
        Player player = new Player { Name = playerName, IsAlive = true };

        bool playing = true;

        while (playing)
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the Adventure, {player.Name}!");
            Console.WriteLine("====================================");
            Console.WriteLine("Instructions: Type A, B, or C when prompted.\n");

            Scenarios(player);

            Console.Write("\nWould you like to play again? (Y/N): ");
            string choice = Console.ReadLine().ToUpper();
            playing = (choice == "Y");
        }

        Console.WriteLine("Thanks for playing!");
    }
    //different scenarios to choose from
    static void Scenarios(Player player)
    {
        Console.Write("Choose a scenario:\n A) The mysterious chamber\n B) Rumble in a jungle\n C) Lone survivor\nEnter A, B, or C: ");
        string answer = Console.ReadLine().ToUpper();
        //.ToUpper converts input letter to uppercase
        switch (answer)
        {
            case "A": // only option for now
                Console.WriteLine("\nWelcome to the mysterious chamber!");
                Game1(player);
                break;
            case "B": // storyline not written yet
                Console.WriteLine("\nWelcome to rumble in a jungle!");
                Game2();
                break;
            case "C": // storyline not written yet
                Console.WriteLine("\nWelcome to lone survivor!");
                Game3();
                break;
            default:
                Console.WriteLine("Invalid input. Please select A, B, or C.");
                break;
        }
    }

    // The first Game
    static void Game1(Player player)
    {
        Console.WriteLine("\nYou awaken in a damp, stone chamber lit by flickering torches. You hear a low growl from the shadows.");
        Console.Write("\nYou see:\n A) A pile of tools and a candle\n B) A creaky door partially open\nEnter A or B: ");
        string answer = Console.ReadLine().ToUpper();

        if (answer == "A")
        {
            Console.WriteLine("\nYou grab a rusty knife and light the candle. The light reveals claw marks on the walls.");
            PlayerHasCandleAndKnife(player);
        }
        else if (answer == "B")
        {
            Console.WriteLine("\nYou sneak toward the door. Suddenly, a lion pounces from the dark!");
            PlayerMovedAway(player);
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }

    static void PlayerMovedAway(Player player)
    {
        Console.Write("\nThe lion snarls and blocks your path. What do you do?\n A) Freeze and play dead\n B) Run and look for a weapon\nEnter A or B: ");
        string answer = Console.ReadLine().ToUpper();

        if (answer == "A")
        {
            EndGame(player, false, "You froze in place, but the lion wasn’t fooled. You became dinner.");
        }
        else if (answer == "B")
        {
            Console.WriteLine("\nYou sprint for the tools. The lion is gaining!");
            Console.Write("You grab:\n A) A torch\n B) A broken spear\nEnter A or B: ");
            string weapon = Console.ReadLine().ToUpper();

            if (weapon == "A")
            {
                EndGame(player, true, "You wave the torch, scaring the lion back into the shadows. You find a way out.");
            }
            else if (weapon == "B")
            {
                EndGame(player, false, "The broken spear snaps, and the lion overpowers you.");
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }

    static void PlayerHasCandleAndKnife(Player player)
    {
        Console.Write("\nYou follow a tunnel to two paths:\n A) One smells of smoke\n B) One echoes with distant humming\nEnter A or B: ");
        string answer = Console.ReadLine().ToUpper();

        if (answer == "A")
        {
            EndGame(player, false, "The tunnel collapses in smoke and fire. You didn’t make it.");
        }
        else if (answer == "B")
        {
            EndGame(player, true, "You find a control room with monitors. You signal for help and escape!");
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }
    static void EndGame(Player player, bool survived, string message)
    {
        Console.WriteLine($"\n{message}");
        string outcome = survived ? "Survived" : "Died";
        //Saving files to the specified path I outlined
        try
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "game_results.txt");
            File.AppendAllText(filePath, $"{DateTime.Now}: {player.Name} - {outcome}: {message}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error writing to file: {ex.Message}");
        }

        if (!survived)
        {
            Console.WriteLine("Game Over!");
        }
        else
        {
            Console.WriteLine("Congratulations!");
        }

        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
    //The Place Holders for Game 2 and 3
    static void Game2()
    {
        Console.WriteLine("[Game2 logic not yet implemented]");
        Console.WriteLine("Press Enter to return to the main menu...");
        Console.ReadLine();
    }

    static void Game3()
    {
        Console.WriteLine("[Game3 logic not yet implemented]");
        Console.WriteLine("Press Enter to return to the main menu...");
        Console.ReadLine();
    }
}
