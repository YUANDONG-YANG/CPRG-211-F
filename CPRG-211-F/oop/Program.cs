﻿// See https://aka.ms/new-console-template for more information
using oop.Models;
using oop.Services;

namespace oop
{
    /// <summary>
    /// Main entry point for the application.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Create four Person objects
            Person ian = new(1, "Ian", "Brooks", "Red", 30, true);
            Person gina = new(2, "Gina", "James", "Green", 18, false);
            Person mike = new(3, "Mike", "Briscoe", "Blue", 45, true);
            Person mary = new(4, "Mary", "Beals", "Yellow", 28, true);

            // Display Gina’s information
            gina.DisplayPersonInfo();

            // Display Mike’s information
            Console.WriteLine(mike);

            // Change Ian’s favorite color and display his information
            ian.ChangeFavoriteColour("White");
            ian.DisplayPersonInfo();

            // Display Mary’s age after 10 years
            Console.WriteLine($"{mary.FirstName} {mary.LastName}'s age in 10 years is: {mary.GetAgeInTenYears()}");

            // Create Relation objects and display relationships
            Relation sisterhood = new Relation("Sisterhood");
            Relation brotherhood = new Relation("Brotherhood");
            sisterhood.ShowRelationship(gina, mary);
            brotherhood.ShowRelationship(ian, mike);

            // Add all Person objects to a list
            List<Person> people = [ian, gina, mike, mary];

            // Calculate the average age
            double averageAge = people.Average(p => p.Age);
            Console.WriteLine($"Average age is: {averageAge:F2}");

            // Find the youngest and oldest person
            Person youngest = people.OrderBy(p => p.Age).First();
            Person oldest = people.OrderByDescending(p => p.Age).First();
            Console.WriteLine($"The youngest person is: {youngest.FirstName}");
            Console.WriteLine($"The oldest person is: {oldest.FirstName}");

            // Find people whose first name starts with M
            var namesStartingWithM = people.Where(static p => p.FirstName.StartsWith("M")).ToList();
            namesStartingWithM.ForEach(Console.WriteLine);


            // Find the person who likes the color blue
            var likesBlue = people.FirstOrDefault(p => p.FavoriteColour == "Blue");
            if (likesBlue != null)
            {
                Console.WriteLine(likesBlue);
            }
        }
    }
}
