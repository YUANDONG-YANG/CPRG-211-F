using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Task 1: Create variables
        Console.WriteLine("Task 1: Create Variables\n");
        int low = GetValidatedInput("Enter the low number (positive integer): ", true);
        int high = GetValidatedInput($"Enter the high number (must be greater than {low}): ", false, low);
        Console.WriteLine($"Low number: {low}, High number: {high}, Difference: {high - low}\n");

        // Task 2: Loops and input validation
        Console.WriteLine("Task 2: Loops and Input Validation Completed.\n");

        // Task 3: Use arrays and file I/O
        Console.WriteLine("Task 3: Use Arrays and File I/O\n");
        List<double> numbers = new List<double>();
        for (int i = low; i <= high; i++)
        {
            numbers.Add(i);
        }

        string filePath = "numbers.txt";
        WriteNumbersToFile(numbers, filePath);
        Console.WriteLine($"Numbers from low to high written in reverse order to the file: {filePath}\n");

        // Read numbers from the file and print the sum
        double sum = CalculateSumFromFile(filePath);
        Console.WriteLine($"The sum of numbers in the file is: {sum}\n");

        // Print primes in the range
        Console.WriteLine("Prime numbers in the range:");
        PrintPrimesInRange(low, high);
    }

    // Method: Get and validate user input
    static int GetValidatedInput(string prompt, bool positiveOnly = false, int greaterThan = int.MinValue)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (int.TryParse(input, out int result) && (!positiveOnly || result > 0) && result > greaterThan)
            {
                return result;
            }
            Console.WriteLine("Invalid input, please try again.");
        }
    }

    // Method: Write numbers to file in reverse order
    static void WriteNumbersToFile(List<double> numbers, string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                writer.WriteLine(numbers[i]);
            }
        }
    }

    // Method: Read numbers from file and calculate the sum
    static double CalculateSumFromFile(string filePath)
    {
        double sum = 0;
        foreach (string line in File.ReadLines(filePath))
        {
            if (double.TryParse(line, out double number))
            {
                sum += number;
            }
        }
        return sum;
    }

    // Method: Print primes in the range
    static void PrintPrimesInRange(int low, int high)
    {
        for (int i = low; i <= high; i++)
        {
            if (IsPrime(i))
            {
                Console.WriteLine(i);
            }
        }
    }

    // Method: Check if a number is prime
    static bool IsPrime(int number)
    {
        if (number < 2) return false;

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0) return false;
        }

        return true;
    }
}
