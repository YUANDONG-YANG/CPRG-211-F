using System;
using oop.Models.Abstract;
namespace oop.Models
{
    class Dog : Animal
    {
        // Constructor
        public Dog(string name, string colour, int age)
        {
            SetName(name);
            SetColour(colour);
            SetAge(age);
        }

        // Implement Eat method
        public override void Eat()
        {
            Console.WriteLine($"{GetName()} the dog eats meat.");
        }
    }
}