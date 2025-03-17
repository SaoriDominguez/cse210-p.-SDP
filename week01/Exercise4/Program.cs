using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");

 // Create a list to store the numbers
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        while (true)
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();
            
            if (int.TryParse(input, out int number))
            {
                if (number == 0)
                {
                    break; // Stop when 0 is entered
                }
                numbers.Add(number);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }

        // Ensure the list is not empty before calculations
        if (numbers.Count > 0)
        {
            // Compute sum
            int sum = 0;
            foreach (int num in numbers)
            {
                sum += num;
            }
            Console.WriteLine($"The sum is: {sum}");

            // Compute average
            double average = (double)sum / numbers.Count;
            Console.WriteLine($"The average is: {average}");

            // Find maximum number
            int maxNumber = numbers[0];
            foreach (int num in numbers)
            {
                if (num > maxNumber)
                {
                    maxNumber = num;
                }
            }
            Console.WriteLine($"The largest number is: {maxNumber}");

            // Stretch Challenge: Find the smallest positive number
            int? smallestPositive = null;
            foreach (int num in numbers)
            {
                if (num > 0 && (smallestPositive == null || num < smallestPositive))
                {
                    smallestPositive = num;
                }
            }
            if (smallestPositive != null)
            {
                Console.WriteLine($"The smallest positive number is: {smallestPositive}");
            }

            // Stretch Challenge: Sort and display the list
            numbers.Sort();
            Console.WriteLine("The sorted list is:");
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }

    }
}