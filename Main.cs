namespace Vinterprojekt_Prog2;

class Program
{
    static void Main(string[] args)
    {
        Hotel hotel = new Hotel("Mars", "Dog");

        Client client = new Client("Peter", 72);

        Borzoi borzoi = new Borzoi(13, client);


        Dog[] dogs = new Dog[3];
        dogs[0] = borzoi;

        Console.WriteLine(dogs.GetType());
        Console.WriteLine(borzoi.GetType());
        Console.WriteLine(dogs.GetType().IsAssignableFrom(borzoi.GetType()));
    }
}
