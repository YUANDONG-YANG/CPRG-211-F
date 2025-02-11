using System;
using oop.Models.Abstract;

namespace oop.Models
{
    // The PartTime class uses the primary constructor syntax.
    // It accepts id, name, address, cellPhone, sin, birthday, postion, hourlyRate, and hoursWorked.
    // The birthday parameter is passed to the base Employee constructor.
    public class PartTime(string id, string name, string address, string cellPhone, long sin, DateTime birthday, string postion, double hourlyRate, double hoursWorked)
        : Employee(id, name, address, cellPhone, sin, birthday, postion)
    {
        // Auto-implemented properties initialized from constructor parameters.
        public double HourlyRate { get; set; } = hourlyRate;
        public double HoursWorked { get; set; } = hoursWorked;

        // For part-time employees, there is no overtime pay.
        public override double CalculateWeeklyPay() => HourlyRate * HoursWorked;

        // Override ToString to include HourlyRate and HoursWorked.
        public override string ToString()
        {
            return base.ToString() + $", HourlyRate={HourlyRate:F2}, HoursWorked={HoursWorked:F2}";
        }
    }
}
