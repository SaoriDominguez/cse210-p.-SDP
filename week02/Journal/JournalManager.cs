using System;
using System.Collections.Generic;
using System.IO;

namespace Week2
{
    public class JournalManager
    {
        private List<JournalEntry> journalEntries = new List<JournalEntry>();
        private static readonly string[] prompts = 
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        public void AddEntry()
        {
            Random random = new Random();
            int promptIndex = random.Next(prompts.Length);
            string prompt = prompts[promptIndex];

            Console.WriteLine($"Prompt: {prompt}");
            Console.Write("Your response: ");
            string response = Console.ReadLine();
            string date = DateTime.Now.ToShortDateString();

            JournalEntry newEntry = new JournalEntry(date, prompt, response);
            journalEntries.Add(newEntry);

            Console.WriteLine("Entry added!");
        }

        public void DisplayJournal()
        {
            if (journalEntries.Count == 0)
            {
                Console.WriteLine("No journal entries found.");
                return;
            }

            foreach (var entry in journalEntries)
            {
                Console.WriteLine($"Date: {entry.Date}");
                Console.WriteLine($"Prompt: {entry.Prompt}");
                Console.WriteLine($"Response: {entry.Response}");
                Console.WriteLine();
            }
        }

        public void SaveJournalToFile()
        {
            Console.Write("Enter the filename to save your journal: ");
            string filename = Console.ReadLine();
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in journalEntries)
                {
                    writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
                }
            }
            Console.WriteLine("Journal saved!");
        }

        public void LoadJournalFromFile()
        {
            Console.Write("Enter the filename to load your journal: ");
            string filename = Console.ReadLine();

            if (File.Exists(filename))
            {
                journalEntries.Clear();
                string[] lines = File.ReadAllLines(filename);
                foreach (var line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        journalEntries.Add(new JournalEntry(parts[0], parts[1], parts[2]));
                    }
                }
                Console.WriteLine("Journal loaded!");
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
    }
}
