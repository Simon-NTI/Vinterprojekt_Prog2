using System.Runtime.CompilerServices;

abstract class Establishment
{
    private string location;
    private string animal;
    private List<Animal> animalsOnSite = new();
    public static List<Establishment> establishments { get; set; } = new List<Establishment>();

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

    private static void PrintAllEstablishmentsOfType(string establishmentType)
    {
        Console.WriteLine("-- " + establishmentType + " Locations --");
        foreach(Establishment establishment in establishments)
        {
            if (establishment.GetType().ToString() == establishmentType)
            {
                Console.WriteLine(establishment.location);
            }
        }
    }
    public virtual void ViewOrModify(int establishmentIndex)
    {

    }

    public static void ChooseAction() {
        Console.WriteLine("What do you want to do?: ");
        Console.WriteLine("1: View or modify hotels\n"
        + "2: View or modify daycares\n"
        + "3: View or modify boardings");

        while (true)
        {
            switch (Utils.GetIntFromUser())
            {
                case 1:
                    PrintAllEstablishmentsOfType("Hotel");
                    break;
                case 2:
                    PrintAllEstablishmentsOfType("Daycare");
                    break;
                case 3:
                    PrintAllEstablishmentsOfType("Boarding");
                    break;
                default:
                    Console.WriteLine("Not a valid input");
                    continue;
            }
            break;
        }

        Console.WriteLine("\nPlease enter the location of the establishment you wish to view or modify");
        string searchLocation = Console.ReadLine();

        int establishmentIndex;
        establishmentIndex = establishments.FindIndex(a => a.location.Equals(searchLocation));
        Console.WriteLine("\n 1: View\n 2: Modify");

        ViewOrModify(establishmentIndex);

    }
}