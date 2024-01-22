abstract class Establishment
{
    public string location { get; set; }
    public string animal { get; set; }
    public List<Animal> animalsOnSite { get;  set; } = new(); 
    public static List<Establishment> establishments { get; set; } = new List<Establishment>();
    public static List<Person> people { get; set; } = new List<Person>();

    enum DogTypes
    {
        Borzoi,
        GoldenRetriever
    }

    enum EstablishmentTypes
    {
        Hotel,
        Boarding,
        Daycare
    }

    protected Establishment(string location, string animal)
    {
        this.location = location;
        this.animal = animal;
    }

    public void AppendNewAnimal()
    {
        Console.Clear();
        switch (animal)
        {
            case "Dog":
                Console.WriteLine("--- Choose a dog type ---");
                for (int i = 0; i < Enum.GetNames<DogTypes>().Length; i++)
                {
                    Console.WriteLine($"{i + 1}: {Enum.GetName(typeof(DogTypes), i)}");
                }

                switch(Utils.GetIntFromUser(1))
                {
                    case 1:
                        //animalsOnSite.Add(new Borzoi(60));
                        break;
                }

                break;
        }
    }

    private void RemoveAnimal()
    {
        Console.Clear();
        foreach(Animal animal in animalsOnSite)
        {
            Console.WriteLine($"Animal name: {animal.name}\nAnimal Id: {animal.idNumber}");
        }
        while(true)
        {
            Console.WriteLine("Please enter the identification number of the animal you wish to remove");

            int searchId = Utils.GetIntFromUser();
            int animalIndex = animalsOnSite.FindIndex(a => a.idNumber.Equals(searchId));

            if(animalIndex != null)
            {
                animalsOnSite.RemoveAt((int)animalIndex);
            }
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

    private static void HandlePeopleDatabase()
    {
        Console.Clear();
        Console.WriteLine();
    }

    private void View()
    {
        Console.Clear();
        Console.WriteLine($"The establishment location is {location}\n"
        + $"The establishment houses {animal}s\n"
        + $"This establishment currently has {animalsOnSite.Count} animals\n");
        
        if(animalsOnSite.Count > 0)
        {
            Console.WriteLine("--- List of animals ---");
            foreach(Animal animal in animalsOnSite)
            {
                Console.WriteLine($"Animal Id: {animal.idNumber}\n"
                + $"- Name: {animal.name}\n"
                + $"- Fur Color: {animal.furColor}\n"
                + $"    - Owner Name: {animal.owner.name}");

                Console.WriteLine();
            }
        }
    }
    
    private void Modify()
    {
        Console.WriteLine("Choose one of the following informations to modify:\n"
        + $"1: Location\n"
        + $"2: Type of animal\n"
        + $"3: Animals currently housed");


        int switchValue = Utils.GetIntFromUser(3);
        while(true)
        {
            switch (switchValue)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("-- Modify Location --\n"
                    + $"Current Location: {location}\n"
                    + $"Please enter new location");
                    location = Utils.GetStringFromUser(true);
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("-- Modify Animal Type --\n"
                    + $"Current Animal type: {animal}\n"
                    + $"Please enter new Animal type");
                    animal = Utils.GetStringFromUser(true);
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine("-- Modify animals currently housed --\n"
                    + $"1: Add new animal to establishment"
                    + $"2: Remove animal from establishment");

                    switch (Utils.GetIntFromUser(2))
                    {
                        case 1:
                            AppendNewAnimal();
                            break;

                        case 2:
                            RemoveAnimal();
                            break;
                    }
                    break;

                default:
                    continue;
            }
        }
    }


    public static void ChooseAction() {
        while (true)
        {
            while (true)
            {
                Console.WriteLine("What do you want to do?:");
                Console.WriteLine("1: View or modify establishments\n"
                + "2: View or modify person database");

                switch (Utils.GetIntFromUser(2))
                {
                    case 1:
                        break;

                    case 2:
                        HandlePeopleDatabase();
                        break;

                    default:
                        continue;
                }
                break;
            }

            Console.Clear();
            Console.WriteLine("Choose an establishment type to view or modify");                            
            for (int i = 0; i < Enum.GetNames<EstablishmentTypes>().Length; i++)
            {
                Console.WriteLine($"{i + 1}: {Enum.GetName(typeof(EstablishmentTypes), i)}");
            }

            while (true)
            {
                switch (Utils.GetIntFromUser(3))
                {
                    case 1:
                        PrintAllEstablishmentsOfType("Hotel");
                        break;
                    case 2:
                        PrintAllEstablishmentsOfType("Boarding");
                        break;
                    case 3:
                        PrintAllEstablishmentsOfType("Daycare");
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
            Console.WriteLine("\n1: View\n2: Modify");

            switch (Utils.GetIntFromUser(2))
            {
                case 1:
                    establishments[establishmentIndex].View();
                    break;
                case 2:
                    establishments[establishmentIndex].Modify();
                    break;
            }
        }
    }
}