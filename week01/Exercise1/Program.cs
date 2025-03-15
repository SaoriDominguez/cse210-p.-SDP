using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise1 Project.");

        // Prompt for the first name
        Console.Write("What is your first name?");
        string firstName = Console.ReadLine();
        
        // Prompt for the Last name
        Console.Write("What is your lastname?");
        string lastName = Console.ReadLine();

        //Display the name in the correct format
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}