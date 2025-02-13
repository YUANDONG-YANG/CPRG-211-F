using oop.Models.Interface;

namespace oop.Models
{
    class Dog2 : IAnimal
    {
        public string Name { get; set; }
        public string Colour { get; set; }
        public double Height { get; set; }
        public int Age { get; set; }

        public string Cry()
        {
            throw new NotImplementedException();
        }

        public void Eat()
        {
            Console.WriteLine("Dogs eat meat");
        }
    }
}