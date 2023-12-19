using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography;

abstract class Establishment
{
    private string location;
    private string animal;
    private List<Animal>? animalsOnSite = new();

    enum DogTypes
    {
        Borzoi,
        GoldenRetriever
    }

    protected Establishment(string location, string animal)
    {
        this.location = location;
        this.animal = animal;
    }

    public void AppendNewAnimal()
    {
        switch (animal)
        {
            case "Dog":
                Console.WriteLine("--- Choose a dog type ---");
                for (int i = 0; i < Enum.GetNames<DogTypes>().Length; i++)
                {
                    Console.WriteLine($"{i + 1}: {Enum.GetName(typeof(DogTypes), i)}");
                }

                switch(GetIntFromUser())
                {
                    case 1:
                    
                        break;
                }

                break;
        }
    }

    private static int GetIntFromUser() 
    {
        string? input = Console.ReadLine();
        while (!int.TryParse(input, out int answer))
        {
            return answer;
        }
        return int.Parse(input);
    }
}