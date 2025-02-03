using System;
using oop.Models;

namespace oop.Services
{
    /// <summary>
    /// Represents a relationship between two people.
    /// </summary>
    public class Relation(string relationshipType)
    {
        public string RelationshipType { get; set; } = relationshipType;

        /// <summary>
        /// Displays the relationship between two Person objects.
        /// </summary>
        public void ShowRelationship(Person person1, Person person2)
        {
            Console.WriteLine($"Relationship between {person1.FirstName} and {person2.FirstName} is: {RelationshipType}");
        }
    }
}
