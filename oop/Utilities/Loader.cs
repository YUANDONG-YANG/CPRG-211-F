using oop.Models;
using oop.Models.Abstract;

namespace oop.Utilities
{
    public static class Loader
    {
        public static List<Employee> LoadEmployeesFromFile(string filePath)
        {
            List<Employee> result = [];

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                return result; // Return an empty list
            }

            string[] lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                // Skip empty or invalid lines
                if (string.IsNullOrWhiteSpace(line)) continue;

                // Assume the format: ID,Name,SIN,RateOrSalary,Hours
                var parts = line.Split(',');
                if (parts.Length < 5)
                {
                    Console.WriteLine($"Invalid line: {line}");
                    continue;
                }

                string id = parts[0].Trim();
                string name = parts[1].Trim();
                if (!long.TryParse(parts[2], out long sin))
                {
                    Console.WriteLine($"Invalid SIN in line: {line}");
                    continue;
                }
                if (!double.TryParse(parts[3], out double rateOrSalary))
                {
                    Console.WriteLine($"Invalid rateOrSalary in line: {line}");
                    continue;
                }
                if (!double.TryParse(parts[4], out double hours))
                {
                    Console.WriteLine($"Invalid hours in line: {line}");
                    continue;
                }

                // Determine the employee type based on the first digit of the ID
                char firstDigit = id.Length > 0 ? id[0] : ' ';
                if (firstDigit >= '0' && firstDigit <= '4')
                {
                    // Salaried
                    result.Add(new Salaried(id, name, sin, rateOrSalary));
                }
                else if (firstDigit >= '5' && firstDigit <= '7')
                {
                    // Wages
                    result.Add(new Wages(id, name, sin, rateOrSalary, hours));
                }
                else if (firstDigit >= '8' && firstDigit <= '9')
                {
                    // PartTime
                    result.Add(new PartTime(id, name, sin, rateOrSalary, hours));
                }
                else
                {
                    Console.WriteLine($"Unknown employee type for ID: {id}");
                }
            }

            return result;
        }
    }
}