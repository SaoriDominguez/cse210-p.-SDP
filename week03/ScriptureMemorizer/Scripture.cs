using System;
using System.Collections.Generic;

public class Scripture
{
    public Reference Reference { get; set; }
    public List<Word> Words { get; set; }

    public Scripture(Reference reference, List<Word> words)
    {
        Reference = reference;
        Words = words;
    }

    public void Display()
    {
        Console.WriteLine(Reference.GetFullReference());
        foreach (var word in Words)
        {
            Console.Write(word.Display() + " ");
        }
        Console.WriteLine();
    }
}
