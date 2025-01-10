using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NumberDifferenceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            double lowNumber = GetValidatedInput("Enter a positive low number: ", IsValidLowNumber);
            double highNumber = GetValidatedInput($"Enter a high number greater than {lowNumber}: ", input => IsValidHighNumber(input, lowNumber));

            // Calculate the difference
            double difference = highNumber - lowNumber;
            Console.WriteLine($"The difference between high and low numbers is: {difference}");

            // Generate a list of numbers from low to high
            List<double> numberList = Enumerable.Range(0, (int)(highNumber - lowNumber + 1))
                                               .Select(i => lowNumber + i)
                                               .ToList();

            // Reverse the list to have numbers from high to low
            numberList.Reverse();

            // Define the file path (you can change this path as needed)
            string filePath = "numbers.txt";

            try
            {
                // Write each number to the file
                WriteNumbersToFile(filePath, numberList);
                Console.WriteLine($"Numbers have been written to {filePath} in reverse order.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while writing to the file: {ex.Message}");
            }

            // Read numbers back from the file and calculate the sum
            try
            {
                List<double> numbersFromFile = ReadNumbersFromFile(filePath);
                double sum = numbersFromFile.Sum();
                Console.WriteLine($"The sum of the numbers read from the file is: {sum}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading from the file: {ex.Message}");
            }

            // Find and print prime numbers between low and high
            List<double> primeNumbers = FindPrimeNumbers(lowNumber, highNumber);
            Console.WriteLine($"Prime numbers between {lowNumber} and {highNumber}: {string.Join(", ", primeNumbers)}");

            // Optional: Keep the console window open until the user presses a key
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        /// <summary>
        /// 获取并验证用户输入的方法。
        /// </summary>
        /// <param name="prompt">提示信息。</param>
        /// <param name="validationFunc">验证函数。</param>
        /// <returns>经过验证的 double 数字。</returns>
        static double GetValidatedInput(string prompt, Func<string, (bool, double)> validationFunc)
        {
            double number;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                var (isValid, parsedNumber) = validationFunc(input);
                if (isValid)
                {
                    number = parsedNumber;
                    break;
                }
            }
            return number;
        }

        /// <summary>
        /// 验证低数是否为正数的方法。
        /// </summary>
        /// <param name="input">用户输入的字符串。</param>
        /// <returns>是否有效，以及解析后的数字。</returns>
        static (bool, double) IsValidLowNumber(string input)
        {
            if (double.TryParse(input, out double number))
            {
                if (number > 0)
                {
                    return (true, number);
                }
                else
                {
                    Console.WriteLine("Low number must be positive. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            return (false, 0);
        }

        /// <summary>
        /// 验证高数是否大于低数的方法。
        /// </summary>
        /// <param name="input">用户输入的字符串。</param>
        /// <param name="lowNumber">低数。</param>
        /// <returns>是否有效，以及解析后的数字。</returns>
        static (bool, double) IsValidHighNumber(string input, double lowNumber)
        {
            if (double.TryParse(input, out double number))
            {
                if (number > lowNumber)
                {
                    return (true, number);
                }
                else
                {
                    Console.WriteLine($"High number must be greater than {lowNumber}. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            return (false, 0);
        }

        /// <summary>
        /// 将数字列表写入文件的方法。
        /// </summary>
        /// <param name="filePath">文件路径。</param>
        /// <param name="numbers">要写入的数字列表。</param>
        static void WriteNumbersToFile(string filePath, List<double> numbers)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (double number in numbers)
                {
                    writer.WriteLine(number);
                }
            }
        }

        /// <summary>
        /// 从文件中读取数字并返回列表的方法。
        /// </summary>
        /// <param name="filePath">文件路径。</param>
        /// <returns>读取的数字列表。</returns>
        static List<double> ReadNumbersFromFile(string filePath)
        {
            List<double> numbers = new List<double>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (double.TryParse(line, out double number))
                    {
                        numbers.Add(number);
                    }
                }
            }
            return numbers;
        }

        /// <summary>
        /// 查找低数和高数之间的质数列表的方法。
        /// </summary>
        /// <param name="low">低数。</param>
        /// <param name="high">高数。</param>
        /// <returns>质数列表。</returns>
        static List<double> FindPrimeNumbers(double low, double high)
        {
            List<double> primes = new List<double>();
            for (double num = Math.Ceiling(low); num <= Math.Floor(high); num++)
            {
                if (IsPrime(num))
                {
                    primes.Add(num);
                }
            }
            return primes;
        }

        /// <summary>
        /// 判断一个数字是否为质数的方法。
        /// 仅整数可以是质数。
        /// </summary>
        /// <param name="number">要检查的数字。</param>
        /// <returns>如果是质数则返回 true，否则返回 false。</returns>
        static bool IsPrime(double number)
        {
            if (number < 2 || number != Math.Floor(number))
                return false;

            int intNumber = (int)number;
            for (int i = 2; i <= Math.Sqrt(intNumber); i++)
            {
                if (intNumber % i == 0)
                    return false;
            }
            return true;
        }
    }
}
