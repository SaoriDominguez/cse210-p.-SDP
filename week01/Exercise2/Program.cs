using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");

 // Ask the user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        string userInput = Console.ReadLine();

        // Validate input
        if (int.TryParse(userInput, out int gradePercentage))
        {
            // Variable to store the letter grade
            string letterGrade = "";
            string sign = "";

            // Determine the letter grade
            if (gradePercentage >= 90)
            {
                letterGrade = "A";
            }
            else if (gradePercentage >= 80)
            {
                letterGrade = "B";
            }
            else if (gradePercentage >= 70)
            {
                letterGrade = "C";
            }
            else if (gradePercentage >= 60)
            {
                letterGrade = "D";
            }
            else
            {
                letterGrade = "F";
            }

            // Determine the sign (+ or -), except for A and F
            int lastDigit = gradePercentage % 10;

            if (letterGrade != "A" && letterGrade != "F")
            {
                if (lastDigit >= 7)
                {
                    sign = "+";
                }
                else if (lastDigit < 3)
                {
                    sign = "-";
                }
            }

            // Print the final grade
            Console.WriteLine($"Your final grade is: {letterGrade}{sign}");

            // Determine if the student passed
            if (gradePercentage >= 70)
            {
                Console.WriteLine("Congratulations! You passed the course.");
            }
            else
            {
                Console.WriteLine("You did not pass, but keep working hard for next time.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }

    }
}