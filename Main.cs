namespace Vinterprojekt_Prog2;

/// <summary>
/// Main method
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        Establishment.establishments.Add(new Hotel("Mars", "Cat", new()));

        Establishment.establishments.Add(new Boarding("Earth", "Dog", new()));

        Establishment.establishments.Add(new Daycare("Jupiter", "Cat", new()));

        Person.people.Add(new Client("Jeff", "15"));
        Person.people.Add(new Client("Bill", "22"));
        Person.people.Add(new Staff("Colt", "17"));

        Establishment.ChooseAction();
    }
}