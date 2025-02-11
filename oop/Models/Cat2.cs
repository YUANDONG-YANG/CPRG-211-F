using System;
using oop.Models.Abstract;
namespace oop.Models
{
    class Cat2 : IAnimal
    {
        public string Name { get; set; }
        public string Colour { get; set; }
        public double Height { get; set; }
        public int Age { get; set; }

        public void Eat()
        {
            Console.WriteLine("Cats eat mice.");
        }

        public string Cry()
        {
            return "Meow!";
        }
    }
}