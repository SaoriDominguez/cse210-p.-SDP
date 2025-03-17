using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

         string playAgain;

        do
        {
            // Create an instance of the random number generator
            Random randomGenerator = new Random();
            // Generate the magic number randomly between 1 and 100
            int magicNumber = randomGenerator.Next(1, 101);
            int guess;  // Variable to store the user's guess
            int attempts = 0;  // Attempt counter

            Console.WriteLine("Welcome to the Guess My Number game!");

            // Start the guessing game
            do
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());  // Read the user's guess
                attempts++;  // Increment the attempt counter

                // Compare the guess with the magic number
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it in {attempts} attempts!");
                }
            } while (guess != magicNumber);  // Continue until the user guesses correctly

            // Ask if the user wants to play again
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine().ToLower();  // Read the answer and convert to lowercase
        } while (playAgain == "yes");  // If the user answers "yes", the game repeats

        Console.WriteLine("Thanks for playing! Goodbye!");  // Farewell message
    }
}