namespace oop.Models.Interface
{
    interface IAnimal
    {
    string Name { get; set; }
    string Colour { get; set; }
    double Height { get; set; }
    int Age { get; set; }

    void Eat();
    string Cry();
    }
}
