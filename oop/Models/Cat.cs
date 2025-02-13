using System;
using oop.Models.Abstract;
namespace oop.Models
{
    class Cat : Animal
    {
        // Constructor
        public Cat(string name, string colour, int age)
        {
            SetName(name);
            SetColour(colour);
            SetAge(age);
        }

        // Implement Eat method
        public override void Eat()
        {
            Console.WriteLine($"{GetName()} the cat eats mice.");
        }
    }
}