using System;
using oop.Models.Abstract;
namespace oop.Models
{
    class Dog : Animal
    {
        public override void Eat()
        {
            Console.WriteLine("Dogs eat meat.");
        }
    }
}