using System.Runtime.CompilerServices;

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

        Establishment.ChooseAction();
    }
}