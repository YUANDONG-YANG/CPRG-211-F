using oop.Models;
using oop.Models.Abstract;
using oop.Utilities;

namespace oop.Services
{
    public class Inheritance
    {
        public static void Run()
        {
            // Assume the file is located at the relative path res/employees.txt
            string filePath = @"F:\dev-workspace\git-hub\oop\res\employees.txt";

            Console.WriteLine($"Looking for file: {Path.GetFullPath(filePath)}");
            // 4a. Populate List<Employee>
            List<Employee> employees = Loader.LoadEmployeesFromFile(filePath);

            // 4b. Calculate the average weekly pay for all employees
            double averageWeeklyPay = employees.Average(e => e.CalculateWeeklyPay());
            Console.WriteLine($"Average weekly pay for all employees: {averageWeeklyPay:F2}");

            // 4c. Calculate the highest weekly pay for Wages employees and their name
            var wagesEmployees = employees.OfType<Wages>();
            if (wagesEmployees.Any())
            {
                // Sort by weekly pay in descending order and take the first
                var highestWageEmp = wagesEmployees
                    .OrderByDescending(w => w.CalculateWeeklyPay())
                    .First();
                Console.WriteLine($"Highest weekly pay (Wages): {highestWageEmp.Name}, {highestWageEmp.CalculateWeeklyPay():F2}");
            }

            // 4d. Calculate the lowest salary for Salaried employees and their name
            var salariedEmployees = employees.OfType<Salaried>();
            if (salariedEmployees.Any())
            {
                // Sort by salary in ascending order and take the first (or use weekly pay, same logic)
                var lowestSalaryEmp = salariedEmployees
                    .OrderBy(s => s.Salary)
                    .First();
                Console.WriteLine($"Lowest salary (Salaried): {lowestSalaryEmp.Name}, {lowestSalaryEmp.Salary:F2}");
            }

            // 4e. Calculate the percentage of employees in each category
            int totalCount = employees.Count;
            if (totalCount > 0)
            {
                int salariedCount = salariedEmployees.Count();
                int wagesCount = wagesEmployees.Count();
                int partTimeCount = employees.OfType<PartTime>().Count();

                Console.WriteLine($"Salaried: {100.0 * salariedCount / totalCount:F2}%");
                Console.WriteLine($"Wages: {100.0 * wagesCount / totalCount:F2}%");
                Console.WriteLine($"PartTime: {100.0 * partTimeCount / totalCount:F2}%");
            }

            Console.ReadLine();
        }

    }
}