using System;

namespace oop.Models.Abstract
{
    // Using primary constructor syntax to define the abstract Employee class.
    // This class includes a Birthday property along with ID, Name, and SIN.
    public abstract class Employee(string id, string name, string address, string cellPhone, long sin, DateTime birthday, string postion)
    {
        // Auto-implemented properties are initialized directly using the constructor parameters.
        public string ID { get; set; } = id;
        public string Name { get; set; } = name;
        public string Address { get; set; } = address;
        public string CellPhone { get; set; } = cellPhone;
        public long SIN { get; set; } = sin;
        public DateTime Birthday { get; set; } = birthday;
        
        public string Postion { get; set; } = postion;
        
        // Each derived class must implement its own logic for calculating the weekly pay.
        public abstract double CalculateWeeklyPay();

        // Override ToString() to provide a common string representation of an Employee.
        public override string ToString()
        {
            return $"[{GetType().Name}] ID={ID}, Name={Name}, SIN={SIN}, Birthday={Birthday:yyyy-MM-dd}";
        }
    }
}
