
using oop.Models.Interface;

namespace oop.Models
{
    class Cat2 : IAnimal
    {
        public string Name { get; set; }
        public string Colour { get; set; }
        public double Height { get; set; }
        public int Age { get; set; }
        public string Cry()
        {
            return "Meow!";
        }
        public void Eat()
        {
            Console.WriteLine("Cats eat mice.");
        }
    }
}