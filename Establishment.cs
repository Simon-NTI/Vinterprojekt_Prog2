
abstract class Establishment
{
    private string location;
    private string animal;
    private List<Animal> animalsOnSite = new();
    private static List<Establishment> establishments = new List<Establishment>();

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

                switch(Utils.GetIntFromUser())
                {
                    case 1:
                        //animalsOnSite.Add(new Borzoi(60));
                        break;
                }

                break;
        }
    }

    public static void ViewOrModify()
    {
        int establishmentIndex;
        Console.WriteLine("View or modify: \n",
        "Please enter the locatin of the establishment you wish to view or modify");
        string searchLocation = Console.ReadLine();

        establishmentIndex = establishments.FindIndex(a => a.location.Equals(searchLocation));
        Console.WriteLine(establishmentIndex);

    }
}