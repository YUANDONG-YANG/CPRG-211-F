using System;

namespace oop.Models
{
    /// <summary>
    /// Represents a person with attributes like ID, name, favorite color, age, and working status.
    /// </summary>
    public class Person(int personId, string firstName, string lastName, string favoriteColour, int age, bool isWorking)
    {
        public int PersonId { get; set; } = personId;
        public string FirstName { get; set; } = firstName;
        public string LastName { get; set; } = lastName;
        public string FavoriteColour { get; set; } = favoriteColour;
        public int Age { get; set; } = age;
        public bool IsWorking { get; set; } = isWorking;

        /// <summary>
        /// Displays the person's ID, name, and favorite color.
        /// </summary>
        public void DisplayPersonInfo()
        {
            Console.WriteLine($"{PersonId}: {FirstName} {LastName}'s favorite colour is {FavoriteColour}");
        }

        /// <summary>
        /// Changes the person's favorite color to a new specified color.
        /// </summary>
        public void ChangeFavoriteColour(string newColour)
        {
            FavoriteColour = newColour;
        }

        /// <summary>
        /// Calculates the person's age in ten years.
        /// </summary>
        public int GetAgeInTenYears()
        {
            return Age + 10;
        }

        /// <summary>
        /// Overrides the ToString method to display all attributes of the person.
        /// </summary>
        public override string ToString()
        {
            return $"PersonId: {personId}\nFirstName: {firstName}\nLastName: {lastName}\nFavoriteColour: {favoriteColour}\nAge: {age}\nIsWorking: {isWorking}\n";
        }

    }
}
