using System;
using oop.Models.Abstract;

namespace oop.Models
{
    public class Salaried : Employee
    {
        // Here, Salary can be understood as "weekly salary" or "annual salary / 52"; it depends on your actual needs.
        public double Salary { get; set; }

        public Salaried(string id, string name, long sin, double salary)
            : base(id, name, sin)
        {
            Salary = salary;
        }

        // Salaried employees receive a fixed salary every week
        public override double CalculateWeeklyPay()
        {
            return Salary;
        }

        public override string ToString()
        {
            return base.ToString() + $", Weekly Salary={Salary}";
        }
    }
}