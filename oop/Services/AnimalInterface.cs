using oop.Models;
using oop.Models.Interface;

public class AnimalInterface
{
    public static void Run()
    {
        Console.WriteLine($"Lab 3: Interfaces");
        List<IAnimal> animals = [];

        // Create and populate a Dog object
        Console.Write("Enter Dog2's Name: ");
        Dog2 dog = new Dog2 { Name = Console.ReadLine() };

        Console.Write("Enter Dog2's Colour: ");
        dog.Colour = Console.ReadLine();

        Console.Write("Enter Dog2's Height: ");
        dog.Height = double.Parse(Console.ReadLine());

        Console.Write("Enter Dog2's Age: ");
        dog.Age = int.Parse(Console.ReadLine());

        Console.WriteLine($"Dog2 Details: Name={dog.Name}, Colour={dog.Colour}, Height={dog.Height}, Age={dog.Age}");
        dog.Eat();
        Console.WriteLine(dog.Cry());

        animals.Add(dog);

        // Create and populate a Cat object
        Console.Write("Enter Cat2's Name: ");
        Cat2 cat = new Cat2 { Name = Console.ReadLine() };

        Console.Write("Enter Cat2's Colour: ");
        cat.Colour = Console.ReadLine();

        Console.Write("Enter Cat2's Height: ");
        cat.Height = double.Parse(Console.ReadLine());

        Console.Write("Enter Cat2's Age: ");
        cat.Age = int.Parse(Console.ReadLine());

        Console.WriteLine($"Cat2 Details: Name={cat.Name}, Colour={cat.Colour}, Height={cat.Height}, Age={cat.Age}");
        cat.Eat();
        Console.WriteLine(cat.Cry());

        animals.Add(cat);

        // Print all animal names in the list
        Console.WriteLine("\nList of Animals:");
        foreach (var animal in animals)
        {
            Console.WriteLine($"Animal's Name={animal.Name}");
        }
    }
}