using System;
using oop.Models.Abstract;

namespace oop.Models
{
    /// <summary>
    /// The Wages class represents an hourly employee whose pay includes overtime.
    /// Overtime is any hours worked beyond 40, paid at 1.5 times the hourly rate.
    /// This class uses the standard constructor syntax.
    /// It requires additional parameters (address, cellPhone, and position) for the base Employee class.
    /// </summary>
    public class Wages : Employee
    {
        // Auto-implemented properties for the hourly rate and hours worked.
        public double HourlyRate { get; set; }
        public double HoursWorked { get; set; }

        /// <summary>
        /// Constructor for Wages.
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <param name="name">Employee Name</param>
        /// <param name="address">Employee Address</param>
        /// <param name="cellPhone">Employee Cell Phone</param>
        /// <param name="sin">Employee SIN</param>
        /// <param name="birthday">Employee Birthday</param>
        /// <param name="position">Employee Position</param>
        /// <param name="hourlyRate">Hourly Rate</param>
        /// <param name="hoursWorked">Hours Worked in the week</param>
        public Wages(string id, string name, string address, string cellPhone, long sin, DateTime birthday, string position, double hourlyRate, double hoursWorked)
            : base(id, name, address, cellPhone, sin, birthday, position)
        {
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }

        /// <summary>
        /// Calculates the weekly pay for a wage employee.
        /// If hours worked is less than or equal to 40, the weekly pay is simply HourlyRate * HoursWorked.
        /// If hours worked exceeds 40, the excess hours are paid at 1.5 times the HourlyRate.
        /// </summary>
        /// <returns>The calculated weekly pay.</returns>
        public override double CalculateWeeklyPay()
        {
            const double OVERTIME_THRESHOLD = 40.0;
            const double OVERTIME_MULTIPLIER = 1.5;

            if (HoursWorked <= OVERTIME_THRESHOLD)
            {
                return HourlyRate * HoursWorked;
            }
            else
            {
                double overtimeHours = HoursWorked - OVERTIME_THRESHOLD;
                double regularPay = OVERTIME_THRESHOLD * HourlyRate;
                double overtimePay = overtimeHours * HourlyRate * OVERTIME_MULTIPLIER;
                return regularPay + overtimePay;
            }
        }

        /// <summary>
        /// Overrides the ToString() method to include additional details specific to Wages employees.
        /// </summary>
        /// <returns>A string representation of the Wages object.</returns>
        public override string ToString()
        {
            return base.ToString() + $", HourlyRate={HourlyRate:F2}, HoursWorked={HoursWorked:F2}";
        }
    }
}
