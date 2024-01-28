namespace Vinterprojekt_Prog2;

class Program
{
    static void Main(string[] args)
    {
        Establishment.establishments.Add(new Hotel("Mars", "Cat"));
        Establishment.establishments.Add(new Hotel("Mercury", "Dog"));

        Establishment.establishments.Add(new Boarding("Saturn", "Cat"));
        Establishment.establishments.Add(new Boarding("Earth", "Dog"));

        Establishment.establishments.Add(new Daycare("Jupiter", "Cat"));
        Establishment.establishments.Add(new Daycare("Uranus", "Cat"));

        Person.people.Add(new Client("Jeff", "15", new()));
        Person.people.Add(new Client("Bill", "22", new()));
        Person.people.Add(new Staff("Colt", "17"));

        Establishment.ChooseAction();
    }
}