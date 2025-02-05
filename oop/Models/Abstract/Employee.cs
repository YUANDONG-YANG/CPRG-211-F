using oop.Models;

namespace oop.Models.Abstract
{

    public abstract class Employee(string id, string name, long sin)
    {
        public string ID { get; set; } = id;
        public string Name { get; set; } = name;
        public long SIN { get; set; } = sin;

        public abstract double CalculateWeeklyPay();

        public override string ToString()
        {
            return $"[{GetType().Name}] ID={ID}, Name={Name}, SIN={SIN}";
        }

    }
}