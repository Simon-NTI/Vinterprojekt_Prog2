abstract class Establishment
{
    public string location { get; set; }
    public string animal { get; set; }
    public List<Animal> animalsOnSite { get;  set; } = new(); 
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

                switch(Utils.GetIntFromUser(1))
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
        switch(switchValue)
        {
            case 1:
                Console.Clear();
                Console.WriteLine($"-- Modify Location --\n"
                + $"Current Location: {location}\n"
                + $"Please enter new location");
                location = Utils.GetStringFromUser(true);
                break;
            
            case 2:
                Console.Clear();
                Console.WriteLine($"-- Modify Animal Type --\n"
                + $"Current Animal type: {animal}\n"
                + $"Please enter new Animal type");
                animal = Utils.GetStringFromUser(true);
                break;
        }
    }


    public static void ChooseAction() {
        while (true)
        {
            Console.WriteLine("What do you want to do?:");
            Console.WriteLine("1: View or modify hotels\n"
            + "2: View or modify daycares\n"
            + "3: View or modify boardings");

            while (true)
            {
                switch (Utils.GetIntFromUser(3))
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