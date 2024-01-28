namespace Vinterprojekt_Prog2;

class Program
{
    static void Main(string[] args)
    {
        Establishment.establishments.Add(new Hotel("Mars", "Cat", new()));
        Establishment.establishments.Add(new Hotel("Mercury", "Dog", new()));

        Establishment.establishments.Add(new Boarding("Saturn", "Cat", new()));
        Establishment.establishments.Add(new Boarding("Earth", "Dog", new()));

        Establishment.establishments.Add(new Daycare("Jupiter", "Cat", new()));
        Establishment.establishments.Add(new Daycare("Uranus", "Cat", new()));

        Person.people.Add(new Client("Jeff", "15", new()));
        Person.people.Add(new Client("Bill", "22", new()));
        Person.people.Add(new Staff("Colt", "17"));

        Establishment.ChooseAction();
    }
}