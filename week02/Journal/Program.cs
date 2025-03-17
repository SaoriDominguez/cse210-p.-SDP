using System;

namespace Week2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Displaying the welcome message
            Console.WriteLine("Hello World! This is the Journal Project.");
            Console.WriteLine("Welcome to the Journal Program!");

            // Create an instance of JournalManager to manage journal operations
            JournalManager journalManager = new JournalManager();
            bool running = true;

            // Main program loop to display menu and take user input
            while (running)
            {
                Console.Clear();
                // Display the options for the user
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display the journal");
                Console.WriteLine("3. Save journal to a file");
                Console.WriteLine("4. Load journal from a file");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        journalManager.AddEntry(); // Call method to add a new journal entry
                        break;
                    case "2":
                        journalManager.DisplayJournal(); // Call method to display journal
                        break;
                    case "3":
                        journalManager.SaveJournalToFile(); // Call method to save journal to a file
                        break;
                    case "4":
                        journalManager.LoadJournalFromFile(); // Call method to load journal from a file
                        break;
                    case "5":
                        running = false; // Exit the program loop
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }

                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }
    }
}
