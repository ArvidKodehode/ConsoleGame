using System;
using System.Collections.Generic;

class Program
{
    static List<string> inventory = new List<string>();
    static int totalTime = 0; // Time counter
    static Random rnd = new Random();

    static void Main()
    {
        ShowRules();
        EnterHouse();
    }

    static void ShowRules()
    {
        Console.WriteLine("Welcome home! Your goal is to go through the house, complete tasks, and get to bed as early as possible.");
        Console.WriteLine("Each task takes time, which is determined by rolling a dice.");
        Console.WriteLine("Some tasks require items that you need to find in other rooms.");
        Console.WriteLine("Try to finish everything quickly so you can go to bed early!\n");
        Console.WriteLine("Press Enter to start...");
        Console.ReadLine();
    }

    static void EnterHouse()
    {
        Console.WriteLine("\nYou enter your house. Where do you want to go?");
        Navigate();
    }

    static void Navigate()
{
    while (true)
    {
        Console.Clear(); // Rydder terminalen før menyen vises
        Console.WriteLine("\nChoose a room:");
        Console.WriteLine("1 - Kitchen");
        Console.WriteLine("2 - Living Room");
        Console.WriteLine("3 - Bathroom");
        Console.WriteLine("4 - Bedroom");
        Console.WriteLine("5 - Check Inventory");
        Console.WriteLine("6 - Quit Game");
        Console.Write("Enter your choice: ");

        string? input = Console.ReadLine();
        string choice = input?.Trim() ?? ""; // Nullsjekk for sikkerhet

        if (choice == "1")
        {
            Kitchen();
        }
        else if (choice == "2")
        {
            LivingRoom();
        }
        else if (choice == "3")
        {
            Bathroom();
        }
        else if (choice == "4")
        {
            Bedroom();
        }
        else if (choice == "5")
        {
            ShowInventory();
        }
        else if (choice == "6")
        {
            Console.WriteLine("You quit the game. See you next time!");
            break;
        }
        else
        {
            Console.WriteLine("Invalid choice. Try again.");
        }
    }
}


    static void Kitchen()
    {
        Console.WriteLine("\nYou enter the kitchen. It's time to cook dinner.");
        Console.WriteLine("Rolling a dice to see how long it takes...");

        int time = RollDice();
        totalTime += time;

        Console.WriteLine($"You finish cooking in {time} minutes.");
        Console.WriteLine("You find a bottle of water. Added to inventory.");
        inventory.Add("water bottle");

        Console.WriteLine("\nPress Enter to go back.");
        Console.ReadLine();
        Navigate();
    }

    static void LivingRoom()
    {
        Console.WriteLine("\nYou enter the living room. You want to watch TV but need to find the remote.");
        if (inventory.Contains("remote"))
        {
            Console.WriteLine("You already have the remote! You turn on the TV.");
        }
        else
        {
            Console.WriteLine("Rolling a dice to see how long it takes to find the remote...");

            int time = RollDice();
            totalTime += time;

            Console.WriteLine($"You find the remote in {time} minutes. Added to inventory.");
            inventory.Add("remote");
        }

        Console.WriteLine("\nPress Enter to go back.");
        Console.ReadLine();
        Navigate();
    }

    static void Bathroom()
    {
        Console.WriteLine("\nYou enter the bathroom. Time to brush your teeth and take a shower.");
        Console.WriteLine("Rolling a dice to see how long it takes...");

        int time = RollDice();
        totalTime += time;

        Console.WriteLine($"You finish everything in {time} minutes.");
        Console.WriteLine("You find your pajamas here. Added to inventory.");
        inventory.Add("pajamas");

        Console.WriteLine("\nPress Enter to go back.");
        Console.ReadLine();
        Navigate();
    }

    static void Bedroom()
{
    Console.Clear();
    Console.WriteLine("\nYou enter the bedroom. Time to sleep!");

    if (inventory.Contains("pajamas"))
    {
        Console.WriteLine("You put on your pajamas and get under the covers.");
        Console.WriteLine($"\n🕒 Total time spent: **{totalTime} minutes** 🕒");
        Console.WriteLine("\n🏆 Congratulations! You have completed your evening routine! 🏆");
        Console.WriteLine("\nPress Enter to exit the game.");
        Console.ReadLine();
        Environment.Exit(0); // Avslutter programmet
    }
    else
    {
        Console.WriteLine("You need your pajamas before going to bed! Check the bathroom.");
        Console.WriteLine("\nPress Enter to go back.");
        Console.ReadLine();
        Navigate();
    }
}



    static void ShowInventory()
    {
        Console.WriteLine("\nInventory:");
        if (inventory.Count == 0)
        {
            Console.WriteLine("Your inventory is empty.");
        }
        else
        {
            foreach (string item in inventory)
            {
                Console.WriteLine($"- {item}");
            }
        }

        Console.WriteLine("\nPress Enter to go back.");
        Console.ReadLine();
        Navigate();
    }

    static int RollDice()
    {
        Console.WriteLine("Press Enter to roll the dice...");
        Console.ReadLine(); // Venter på at spilleren trykker Enter før terningen kastes

        int roll = rnd.Next(1, 7); // Kaster en terning (1-6)
        int timeSpent = roll * 5; // Tid i minutter (f.eks. 1-6 ganger 5 min)
        
        Console.WriteLine($"You rolled a {roll}, it takes {timeSpent} minutes.");

        return timeSpent;
    }
}
