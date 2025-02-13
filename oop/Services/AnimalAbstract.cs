using oop.Models;
namespace oop.Services
{
    public class AnimalAbstract
    {
        public static void Run()
        {
            Console.WriteLine($"Lab 3:Abstract Classes");
            //Lab 3: Interfaces and Abstract Classes
            // Ask for dog details
            Console.Write("Enter the dog's name: ");
            string dogName = Console.ReadLine();
            Console.Write("Enter the dog's colour: ");
            string dogColour = Console.ReadLine();
            Console.Write("Enter the dog's age: ");
            int dogAge = int.Parse(Console.ReadLine());

            // Create Dog object
            Dog myDog = new Dog(dogName, dogColour, dogAge);
            Console.WriteLine($"\nDog Details:\nName: {myDog.GetName()}\nColour: {myDog.GetColour()}\nAge: {myDog.GetAge()}");
            myDog.Eat();

            // Ask for cat details
            Console.Write("\nEnter the cat's name: ");
            string catName = Console.ReadLine();
            Console.Write("Enter the cat's colour: ");
            string catColour = Console.ReadLine();
            Console.Write("Enter the cat's age: ");
            int catAge = int.Parse(Console.ReadLine());

            // Create Cat object
            Cat myCat = new Cat(catName, catColour, catAge);
            Console.WriteLine($"\nCat Details:\nName: {myCat.GetName()}\nColour: {myCat.GetColour()}\nAge: {myCat.GetAge()}");
            myCat.Eat();

            // Prevent console from closing immediately
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
