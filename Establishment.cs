abstract class Establishment
{
    public string Location { get; set; }
    public string animal { get; set; }
    public List<Animal> animalsOnSite { get;  set; } = new(); 
    public static List<Establishment> establishmentDatabase { get; set; } = new List<Establishment>();

    enum EstablishmentTypes
    {
        Hotel,
        Boarding,
        Daycare
    }

    protected Establishment(string Location, string animal)
    {
        this.Location = Location;
        this.animal = animal;
    }

    public void AppendNewAnimal()
    {
        Console.Clear();
        switch (animal)
        {
            case "Dog":
                Console.WriteLine("--- Choose a dog type ---");
                for (int i = 0; i < Enum.GetNames<Dog.DogTypes>().Length; i++)
                {
                    Console.WriteLine($"{i + 1}: {Enum.GetName(typeof(Dog.DogTypes), i)}");
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

    private static List<Establishment> GetAllEstablishmentsOfType(string establishmentType)
    {
        List<Establishment> foundEstablishments = new List<Establishment>();
        Console.WriteLine("-- " + establishmentType + " Locations --");
        foreach(Establishment establishment in establishmentDatabase)
        {
            if (establishment.GetType().ToString() == establishmentType)
            {
                Console.WriteLine(establishment.Location);
                foundEstablishments.Add(establishment);
            }
        }
        return foundEstablishments;
    }

    private static void HandlePeopleDatabase()
    {
        Console.Clear();
        Console.WriteLine();
    }

    private void View()
    {
        Console.Clear();
        Console.WriteLine($"The establishment Location is {Location}\n"
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
            }
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    
    private void Modify()
    {
        Console.Clear();
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
                    + $"Current Location: {Location}\n"
                    + $"Please enter new Location");
                    Location = Utils.GetStringFromUser(true);
                    Console.Clear();
                    Console.WriteLine($"Successfully changed Location to {Location}\n"
                    + "Press any key to continue...");
                    Console.ReadKey();
                    return;

                case 2:
                    Console.Clear();
                    Console.WriteLine("-- Modify Animal Type --\n"
                    + $"Current Animal type: {animal}\n"
                    + $"Please enter new Animal type");
                    animal = Utils.GetStringFromUser(true);
                    Console.Clear();
                    Console.WriteLine($"Successfully changed animal type to {animal}\n"
                    + "Press any key to continue...");
                    Console.ReadKey();
                    return;

                case 3:
                    Console.Clear();
                    Console.WriteLine("-- Modify animals currently housed --\n"
                    + $"1: Add new animal to establishment\n"
                    + $"2: Remove animal from establishment");

                    int input = Utils.GetIntFromUser(2);
                    Console.Clear();

                    switch (input)
                    {
                        case 1:
                            AppendNewAnimal();
                            break;

                        case 2:
                            if(animalsOnSite.Count == 0)
                            {
                                Console.WriteLine("This establishment does not have any animals");
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                                break;
                            }
                            RemoveAnimal();
                            break;
                    }
                    return;

                default:
                    continue;
            }
        }
    }
    public static void ChooseAction() {
        while (true)
        {
            Console.Clear();
            while (true)
            {
                bool shouldContinue = true;
                Console.WriteLine("What do you want to do?:\n"
                + "1: View or modify establishment database\n"
                + "2: View or modify person database\n"
                + "3: View or modify animal database\n"
                + "4: Close application");

                switch (Utils.GetIntFromUser(4))
                {
                    case 1:
                        shouldContinue = false;
                        break;

                    case 2:
                        HandlePeopleDatabase();
                        break;

                    case 3:
                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("Not a valid option");
                        continue;
                }

                if(shouldContinue)
                {
                    continue;
                }
                else
                {
                    break;
                }
            }

            Console.Clear();
            Console.WriteLine("Choose an establishment type to view or modify");                            
            for (int i = 0; i < Enum.GetNames<EstablishmentTypes>().Length; i++)
            {
                Console.WriteLine($"{i + 1}: {Enum.GetName(typeof(EstablishmentTypes), i)}");
            }


            List<Establishment> foundEstablishments = new List<Establishment>();
            

            //TODO instead of manually writing a case for every establishment type,
            //TODO use the EstablishmentTypes enum to generate cases instead

            while (true)
            {
                int input = Utils.GetIntFromUser(Enum.GetNames(typeof(EstablishmentTypes)).Length);
                Console.Clear();
                switch (input)
                {
                    case 1:
                        foundEstablishments = GetAllEstablishmentsOfType("Hotel"); 
                        break;
                    case 2:
                        foundEstablishments = GetAllEstablishmentsOfType("Boarding");
                        break;
                    case 3:
                        foundEstablishments = GetAllEstablishmentsOfType("Daycare");
                        break;
                    default:
                        Console.WriteLine("Not a valid input");
                        continue;
                }

                if(foundEstablishments.Count == 0)
                {
                    Console.WriteLine("No establishmentDatabase of this type was found");
                    continue;
                }

                break;
            }

            int establishmentIndex;
            Console.WriteLine("Please enter the Location of the establishment you wish to view or modify");

            while (true)
            {
                string searchLocation = Utils.GetStringFromUser(true);
                establishmentIndex = foundEstablishments.FindIndex(a => a.Location.Equals(searchLocation));

                if (establishmentIndex == -1)
                {
                    Console.WriteLine("An establishment was not found at this Location\n"
                    + "Please enter a new Location");
                    continue;
                }
                Console.Clear();
                Console.WriteLine($"Establishment successfully found at {searchLocation}");
                break;
            }

            Console.WriteLine("What do you wish to do?\n"
            + "1: View\n"
            + "2: Modify");

            switch (Utils.GetIntFromUser(2))
            {
                case 1:
                    establishmentDatabase[establishmentIndex].View();
                    break;
                case 2:
                    establishmentDatabase[establishmentIndex].Modify();
                    break;
            }
        }
    }
}