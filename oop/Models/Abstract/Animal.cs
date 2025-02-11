 using System;

 namespace oop.Models.Abstract

 abstract class Animal
    {
        // Properties
        public string Name { get; set; }
        public string Colour { get; set; }
        public int Age { get; set; }

        // Getter and Setter Methods
        public string GetName() { return Name; }
        public void SetName(string name) { Name = name; }

        public string GetColour() { return Colour; }
        public void SetColour(string colour) { Colour = colour; }

        public int GetAge() { return Age; }
        public void SetAge(int age) { Age = age; }

        // Abstract method to be overridden in derived classes.
        public abstract void Eat();
    }
