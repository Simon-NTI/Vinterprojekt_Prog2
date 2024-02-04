/// <summary>
/// Contins all information and methods for handling establishment objects
/// </summary>
abstract class Establishment
{
    public string location { get; set; }
    public string animal { get; set; }
    public List<Animal> animalsOnSite { get; } = new(); 
    public static List<Establishment> establishments { get; set; } = new List<Establishment>();

    enum EstablishmentTypes
    {
        Hotel,
        Boarding,
        Daycare
    }

    //TODO Implement the Staff class into establishment

    /// <summary>
    /// Constructor, only used in subclasses 
    /// </summary>
    public Establishment(string location, string animal, List<Animal> animalsOnSite)
    {
        this.location = location;
        this.animal = animal;
        this.animalsOnSite = animalsOnSite;
    }

    /// <summary>
    /// Prompts the user to add an animal to the establishment
    /// </summary>
    
    //TODO This method should only accept animals whose type matches the given type of the establishment
    public void AppendAnimal()
    {
        Console.Clear();
        if(Animal.animals.Count == 0)
        {
            Console.WriteLine("The database is empty\n"
            + "Press any key to continue...");
            Console.ReadKey();
        }

        while(true)
        {
            Animal animal = Animal.FindAnimalWithId(this.animal);

            if(animalsOnSite.FindIndex(a => a.id.Equals(animal.id)) != -1)
            {
                Console.WriteLine("This animal is already housed here");
                continue;
            }
            else
            {
                animalsOnSite.Add(animal);
                Console.WriteLine("Successfully added animal to establishment\n"
                + "Press any key to continue...");
                Console.ReadKey();
                return;
            }
        }
    }

    /// <summary>
    /// Prompts the user to remove an animal from the establishment
    /// </summary>
    private void RemoveAnimal()
    {
        Console.Clear();
        foreach(Animal animal in animalsOnSite)
        {
            Console.WriteLine($"Animal Name: {animal.name}\n"
            + $"- Animal Id: {animal.id}\n");
        }
        while(true)
        {
            Console.WriteLine("Please enter the identification number of the animal you wish to remove");

            string searchId = IUtils.GetStringFromUser(false);
            int animalIndex = animalsOnSite.FindIndex(a => a.id.Equals(searchId));

            if(animalIndex != -1)
            {
                animalsOnSite.RemoveAt(animalIndex);
                Console.WriteLine($"Successfully removed animal with id {searchId}");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("No animal with this id was found");
                continue;
            }
        }
    }

    /// <summary>
    /// Returns a list of all establishment object who's type matches the given one
    /// </summary>
    private static List<Establishment> GetAllEstablishmentsOfType(string establishmentType)
    {
        List<Establishment> foundEstablishments = new List<Establishment>();
        Console.WriteLine("-- " + establishmentType + " Locations --");
        foreach(Establishment establishment in establishments)
        {
            if (establishment.GetType().ToString() == establishmentType)
            {
                Console.WriteLine(establishment.location);
                foundEstablishments.Add(establishment);
            }
        }
        return foundEstablishments;
    }

    /// <summary>
    /// Prints all associated information of the given establishment object
    /// </summary>
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
                Console.WriteLine($"Animal Id: {animal.id}\n"
                + $"- Name: {animal.name}\n"
                + $"- Fur Color: {animal.furColor}\n"
                + $"- Owner Name: {animal.owner.name}\n"
                + $"- - Owner Id: {animal.owner.id}\n");
            }
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    /// <summary>
    /// Prompts the user to choose a field to modify, then modifes it according to player input
    /// </summary>
    private void Modify()
    {
        Console.Clear();
        Console.WriteLine("Choose one of the following informations to modify:\n"
        + $"1: location\n"
        + $"2: Type of animal\n"
        + $"3: Animals currently housed");


        int switchValue = IUtils.GetIntFromUser(3);
        while(true)
        {
            switch (switchValue)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("-- Modify location --\n"
                    + $"Current location: {location}\n"
                    + $"Please enter new location");
                    location = IUtils.GetStringFromUser(true);
                    Console.Clear();
                    Console.WriteLine($"Successfully changed location to {location}\n"
                    + "Press any key to continue...");
                    Console.ReadKey();
                    return;

                case 2:
                    Console.Clear();
                    Console.WriteLine("-- Modify Animal Type --\n"
                    + $"Current Animal type: {animal}\n"
                    + $"Please enter new Animal type");
                    animal = IUtils.GetStringFromUser(true);
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

                    int input = IUtils.GetIntFromUser(2);
                    Console.Clear();

                    switch (input)
                    {
                        case 1:
                            AppendAnimal();
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

    /// <summary>
    /// Takes in numerous inputs from the user and adds a new establishment object to the establishments list
    /// </summary>
    private static void AddNewEstablishment()
    {
        Console.Clear();
        string location = "";
        while(true)
        {
            Console.WriteLine("Enter the location of the establishment");
            location = IUtils.GetStringFromUser(true);

            if(establishments.FindIndex(a => a.location.Equals(location)) == -1)
            {
                break;
            }
            else
            {
                Console.WriteLine("An establishment already exists at this location\n"
                + "Press any key to continue...");
                Console.ReadKey();
            }
        }

        Console.Clear();
        Console.WriteLine("What type of animal does this establishment house?");

        //TODO check against the animalTypes enum to make sure the given type actually exists
        string animalType = IUtils.GetStringFromUser(true);

        Console.Clear();
        List<Animal> animals = new();

        bool addAnimals = true;
        if(Animal.animals.Count == 0)
        {
            addAnimals = false;
        }
        else
        {
            Console.WriteLine("Add animals to establishment?\n"
            + "1: Yes\n"
            + "2: No");
        }

        while(addAnimals)
        {
            bool shouldContinue = true;
            switch(IUtils.GetIntFromUser(2))
            {
                case 1:
                    Animal animal = Animal.FindAnimalWithId(null);
                    if(animals.FindIndex(a => a.id.Equals(animal.id)) != -1)
                    {
                        Console.WriteLine("This person a already owns this pet");
                        continue;
                    }
                    else
                    {
                        animals.Add(animal);
                    }
                    break;

                case 2:
                    shouldContinue = false;
                    break;
            }

            if(!shouldContinue)
            {
                break;
            }

            Console.WriteLine("Add another pet?\n"
            + "1: Yes\n"
            + "2: No");

            switch(IUtils.GetIntFromUser(2))
            {
                case 1:
                    break;
                
                case 2:
                    shouldContinue = false;
                    break;
            }

            if(!shouldContinue)
            {
                break;
            }
        }

        Console.WriteLine("Choose an establishment type");                            
        for (int i = 0; i < Enum.GetNames<EstablishmentTypes>().Length; i++)
        {
            Console.WriteLine($"{i + 1}: {Enum.GetName(typeof(EstablishmentTypes), i)}");
        }

        int input = IUtils.GetIntFromUser(Enum.GetNames(typeof(EstablishmentTypes)).Length);
        Console.Clear();
        switch (input)
        {
            case 1:
                establishments.Add(new Hotel(location, animalType, animals));
                break;

            case 2:
                establishments.Add(new Boarding(location, animalType, animals));
                break;

            case 3:
                establishments.Add(new Daycare(location, animalType, animals));
                break;
        }

        Console.WriteLine("Successfully added establishment to database\n"
        + "Press any key to continue...");
        Console.ReadKey();

    }

    /// <summary>
    /// Prints all elements in the establishments list 
    /// </summary>
    private static void PrintAllEstablishments()
    {
        Console.Clear();
        foreach(Establishment establishment in establishments)
        {
            Console.WriteLine($"Location: {establishment.location}\n"
            + $"Type: {establishment.GetType()}\n"
            + $"Animal type: {establishment.animal}");

            if (establishment.animalsOnSite.Count > 0)
            {
                Console.WriteLine($"This establishment has {establishment.animalsOnSite.Count} animal(s)");
                foreach (Animal animal in establishment.animalsOnSite)
                {
                    Console.WriteLine($"- Id: {animal.id}\n"
                    + $"- - Name: {animal.name}\n"
                    + $"- - Fur Color: {animal.furColor}\n"
                    + $"- - Owner Name: {animal.owner.name}\n"
                    + $"- - - Owner Id: {animal.owner.id}\n");
                }
            }
            else
            {
                Console.WriteLine("This establishment houses no animals\n");
            }
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    /// <summary>
    /// Initial method for this class, is only called once
    /// </summary>
    public static void ChooseAction() {
        while (true)
        {
            while (true)
            {
                Console.Clear();
                bool shouldContinue = true;
                Console.WriteLine("What do you wish to do?:\n"
                + "1: View or modify existing establishments in database\n"
                + "2: View all establishments in database\n"
                + "3: Add establishment to database\n"
                + "4: View or modify person database\n"
                + "5: View or modify animal database\n"
                + "6: Close application");

                switch (IUtils.GetIntFromUser(6))
                {
                    case 1:
                        shouldContinue = false;
                        break;

                    case 2:
                        PrintAllEstablishments();
                        break;

                    case 3:
                        AddNewEstablishment();
                        break;

                    case 4:
                        Person.HandlePeopleDatabase();
                        break;

                    case 5:
                        Animal.HandleAnimalsDatabase();
                        break;

                    case 6:
                        return;
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


            //TODO instead of manually writing a case for every establishment type,
            //TODO use the EstablishmentTypes enum to generate cases instead

            List<Establishment> foundEstablishments = new List<Establishment>();
            while (true)
            {
                int input = IUtils.GetIntFromUser(Enum.GetNames(typeof(EstablishmentTypes)).Length);
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
                    Console.WriteLine("No establishment of this type was found");
                    continue;
                }

                break;
            }



            int establishmentIndex;
            Console.WriteLine("Please enter the location of the establishment you wish to view or modify");

            while (true)
            {
                string searchLocation = IUtils.GetStringFromUser(true);
                establishmentIndex = foundEstablishments.FindIndex(a => a.location.Equals(searchLocation));
                if (establishmentIndex == -1)
                {
                    Console.WriteLine("An establishment was not found at this location\n"
                    + "Please enter a new location");
                    continue;
                }
                establishmentIndex = establishments.FindIndex(a => a.location.Equals(searchLocation));
                Console.Clear();
                Console.WriteLine($"Establishment successfully found at {searchLocation}");
                break;
            }

            Console.WriteLine("What do you wish to do?\n"
            + "1: View\n"
            + "2: Modify\n"
            + "3: Remove from database");

            switch (IUtils.GetIntFromUser(3))
            {
                case 1:
                    establishments[establishmentIndex].View();
                    break;
                case 2:
                    establishments[establishmentIndex].Modify();
                    break;
                case 3:
                    Console.WriteLine($"Establishment with location {establishments[establishmentIndex].location} successfully removed from database\n"
                    + "Press any key to continue...");
                    establishments.RemoveAt(establishmentIndex);
                    Console.ReadKey();
                    break;
            }
        }
    }
}