 using System;

namespace oop.Models.Abstract{

 abstract class Animal
    {
        private string name;
        private string colour;
        private int age;

        // Getter and Setter Methods
        public string GetName() { return name; }
        public void SetName(string name) { this.name = name; }

        public string GetColour() { return colour; }
        public void SetColour(string colour) { this.colour = colour; }

        public int GetAge() { return age; }
        public void SetAge(int age) { this.age = age; }

        // Abstract method to be implemented in derived classes
        public abstract void Eat();
    }
}