using System;
using oop.Models.Abstract;

namespace oop.Models
{
    public class Salaried : Employee
    {
        // Here, Salary can be understood as the "weekly salary" or "annual salary / 52" depending on your needs.
        public double Salary { get; set; }

        // The constructor now accepts a DateTime parameter for the employee's birthday.
        public Salaried(string id, string name, string address, string cellPhone, long sin, DateTime birthday, string postion, double salary)
            : base(id, name, address, cellPhone, sin, birthday, postion)
        {
            Salary = salary;
        }

        // Salaried employees receive a fixed salary every week.
        public override double CalculateWeeklyPay() => Salary;

        public override string ToString()
        {
            return base.ToString() + $", Weekly Salary={Salary:F2}";
        }
    }
}
