using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

public class Program
{
    static void Main()
    {
        // Category selection
        Console.WriteLine("Choose a category: 1. Faith  2. Love");
        int choice = int.Parse(Console.ReadLine());
        List<Scripture> selectedCategory = choice == 1 ? FaithScriptures() : LoveScriptures();

        // Randomly pick a scripture from the selected category
        Random random = new Random();
        Scripture currentScripture = selectedCategory[random.Next(selectedCategory.Count)];

        // Timer
        Console.WriteLine("You have 5 seconds to memorize this scripture...");
        currentScripture.Display();
        Thread.Sleep(5000);  // Wait for 5 seconds
        Console.Clear();

        // Start hiding words
        HideWords(currentScripture);

        // Save progress
        SaveProgress(currentScripture);
    }

    static List<Scripture> FaithScriptures()
    {
        return new List<Scripture>
        {
            new Scripture(new Reference("Hebrews", 11, 1), new List<Word> { new Word("Now"), new Word("faith"), new Word("is"), new Word("the"), new Word("substance"), new Word("of"), new Word("things"), new Word("hoped"), new Word("for") }),
            new Scripture(new Reference("James", 2, 17), new List<Word> { new Word("Even"), new Word("so"), new Word("faith"), new Word("if"), new Word("it"), new Word("hath"), new Word("not"), new Word("works"), new Word("is"), new Word("dead") })
        };
    }

    static List<Scripture> LoveScriptures()
    {
        return new List<Scripture>
        {
            new Scripture(new Reference("1 John", 4, 19), new List<Word> { new Word("We"), new Word("love"), new Word("him"), new Word("because"), new Word("he"), new Word("first"), new Word("loved"), new Word("us") }),
            new Scripture(new Reference("1 Corinthians", 13, 4), new List<Word> { new Word("Love"), new Word("is"), new Word("patient"), new Word("love"), new Word("is"), new Word("kind"), new Word("it"), new Word("does"), new Word("not"), new Word("envy") })
        };
    }

    static void HideWords(Scripture scripture)
    {
        foreach (var word in scripture.Words)
        {
            word.IsHidden = true;
            Console.Clear();
            scripture.Display();
            Thread.Sleep(1000);  // Wait for 1 second before hiding the next word
        }
    }

    static void SaveProgress(Scripture scripture)
    {
        using (StreamWriter writer = new StreamWriter("progress.txt"))
        {
            foreach (var word in scripture.Words)
            {
                writer.WriteLine($"{word.Text} {word.IsHidden}");
            }
        }
    }

    static Scripture LoadProgress()
    {
        if (File.Exists("progress.txt"))
        {
            List<Word> words = new List<Word>();
            string[] lines = File.ReadAllLines("progress.txt");

            foreach (var line in lines)
            {
                var parts = line.Split(' ');
                words.Add(new Word(parts[0]) { IsHidden = bool.Parse(parts[1]) });
            }

            return new Scripture(new Reference("John", 3, 16), words);
        }
        return null;
    }
}
