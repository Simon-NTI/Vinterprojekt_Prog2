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
                break;
        }
    }
}