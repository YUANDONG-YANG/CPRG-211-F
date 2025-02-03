using oop.Models;

namespace oop.Tests
{
    /// <summary>
    /// Unit tests for the Person class.
    /// </summary>
    public class PersonTests
    {
 
        public void TestGetAgeInTenYears()
        {
            var person = new Person(1, "Test", "User", "Red", 20, true);
            person.ChangeFavoriteColour("Blue");
        }

        public void TestChangeFavoriteColour()
        {
            var person = new Person(1, "Test", "User", "Red", 20, true);
            person.ChangeFavoriteColour("Blue");
        }
    }
}
