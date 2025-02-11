using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using oop.Models;
using oop.Models.Abstract;

namespace oop.Utilities
{
    public static class Loader
    {
        public static List<Employee> LoadEmployeesFromFile(string filePath)
        {
            // Initialize the result list.
            List<Employee> employees = new List<Employee>();

            // Check if the file exists.
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                return employees;
            }

            try
            {
                // Read each line of the file (using ReadLines for better memory performance).
                foreach (var line in File.ReadLines(filePath))
                {
                    // Skip empty or whitespace-only lines.
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    // Use colon as the delimiter.
                    // Expected formats:
                    // Salaried employees (ID starts with 0–4):  
                    //   ID:Name:Address:Phone:SIN:Birthday:Department:Salary
                    //
                    // Wage/PartTime employees (ID starts with 5–9):  
                    //   ID:Name:Address:Phone:SIN:Birthday:Department:HourlyRate:Hours
                    var parts = line.Split(':');

                    // Check for the minimum number of fields (8 fields for salaried employees).
                    if (parts.Length < 8)
                    {
                        Console.WriteLine($"Invalid line (insufficient fields): {line}");
                        continue;
                    }
                    // Extract common fields.
                    string id = parts[0].Trim();
                    string name = parts[1].Trim();
                    string address = parts[2].Trim();
                    string cellPhone = parts[3].Trim();
                    long sin = long.Parse(parts[4].Trim());
                    string position = parts[6].Trim();
                    // Parse the Birthday from field 6 (index 5).
                    DateTime birthday;
                    if (!DateTime.TryParse(parts[5].Trim(), out birthday))
                    {
                        Console.WriteLine($"Invalid Birthday in line: {line}. Using default date 1900-01-01.");
                        birthday = new DateTime(1900, 1, 1);
                    }

                    // Determine the employee type based on the first digit of the ID.
                    char firstDigit = id.Length > 0 ? id[0] : ' ';
                    if (firstDigit >= '0' && firstDigit <= '4')
                    {
                        // Salaried employees are expected to have exactly 8 fields.
                        if (parts.Length != 8)
                        {
                            Console.WriteLine($"Invalid salaried employee line (expected 8 fields): {line}");
                            continue;
                        }
                        // Salary is in field 8 (index 7).
                        if (!double.TryParse(parts[7].Trim(), out double salary))
                        {
                            Console.WriteLine($"Invalid Salary in line: {line}");
                            continue;
                        }
                        // Create a Salaried employee.
                        employees.Add(new Salaried(id, name, address, cellPhone, sin, birthday, position, salary));
                    }
                    else if (firstDigit >= '5' && firstDigit <= '9')
                    {
                        // Wage/PartTime employees are expected to have exactly 9 fields.
                        if (parts.Length != 9)
                        {
                            Console.WriteLine($"Invalid wage/part-time employee line (expected 9 fields): {line}");
                            continue;
                        }
                        // Hourly Rate is in field 8 (index 7) and Hours is in field 9 (index 8).
                        if (!double.TryParse(parts[7].Trim(), out double hourlyRate))
                        {
                            Console.WriteLine($"Invalid Hourly Rate in line: {line}");
                            continue;
                        }
                        if (!double.TryParse(parts[8].Trim(), out double hours))
                        {
                            Console.WriteLine($"Invalid Hours in line: {line}");
                            continue;
                        }
                        // For IDs starting with 5-7, create a Wages employee.
                        if (firstDigit >= '5' && firstDigit <= '7')
                        {
                            employees.Add(new Wages(id, name, address, cellPhone, sin, birthday, position, hourlyRate, hours));
                        }
                        // For IDs starting with 8-9, create a PartTime employee.
                        else if (firstDigit >= '8' && firstDigit <= '9')
                        {
                            employees.Add(new PartTime(id, name, address, cellPhone, sin, birthday, position, hourlyRate, hours));
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Unknown employee type for ID: {id}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file {filePath}: {ex.Message}");
            }

            return employees;
        }
    }
}
