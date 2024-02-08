using System.Reflection;

/// <summary>
/// Class for handling and storing data for all derivatives of the animal class
/// </summary>
abstract class Animal
{
    public static List<Animal> animals { get; } = new();
    public string furColor {get; }
    public string name { get; }
    public string id { get; } // Id is unique for each instance of this class
    public Person owner { get; }

    /// <summary>
    /// Constructor, only used in subclasses
    /// </summary>
    public Animal(string id, string name, string furColor , Person owner)
    {
        this.id = id;
        this.name = name;
        this.furColor = furColor;
        this.owner = owner;
    }

    public enum AnimalTypes
    {
        Dog,
        Cat
    }

    /// <summary>
    /// Inital method for handling animal objects
    /// </summary>
    public static void HandleAnimalsDatabase()
    {
        Console.Clear();
        Console.WriteLine("What do you wish to do?\n"
        + "1: View all animals with name\n"
        + "2: View an animal based on id \n"
        + "3: View all animals in database\n"
        + "4: Remove an animal from the database\n"
        + "5: Add an animal to the database");

        switch(IUtils.GetIntFromUser(5))
        {
            case 1:
                FindAnimalsWithName();
                break;

            case 2:
                FindAnimalWithId(null);
                break;

            case 3:
                PrintAllAnimals(true);
                break;

            case 4:
                RemoveAnimal();
                break;

            case 5:
                AddNewAnimal();
                break;
        }
    }

    /// <summary>
    /// Prints all fields of all elements in the animals list
    /// </summary>
    private static void PrintAllAnimals(bool pause)
    {
        Console.Clear();
        if(animals.Count > 0)
        {
            foreach(Animal animal in animals)
            {
                Console.WriteLine($"Id: {animal.id}\n"
                + $"- Name: {animal.name}\n"
                + $"- Type: {animal.GetType()}\n"
                + $"- Fur Color: {animal.furColor}\n"
                + $"- Owner Name: {animal.owner.name}\n"
                + $"- - Owner Id: {animal.owner.id}\n");
            }
        }
        else
        {
            Console.WriteLine("The database is empty");
        }

        if(pause)
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    /// <summary>
    /// Prints all fields of animal objects who's name matches the player input
    /// </summary>
    private static void FindAnimalsWithName()
    {
        List<Animal> foundAnimals = new();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Enter a name to search for:");
            string nameToSearch = IUtils.GetStringFromUser(true);
            foundAnimals = animals.FindAll(a => a.name.Equals(nameToSearch));

            if (foundAnimals.Count > 0)
            {
                Console.WriteLine($"-- Found {foundAnimals.Count} animals with the name {nameToSearch} --");
                foreach(Animal animal in foundAnimals)
                {
                    Console.WriteLine($"Id {animal.id}\n"
                    + $"- Name: {animal.name}\n"
                    + $"- Fur Color: {animal.furColor}\n"
                    + $"- Owner Name: {animal.owner.name}\n"
                    + $"- - Owner Id: {animal.owner.id}");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("No animals with this name was found in the database");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                continue;
            }
        }
    }

    /// <summary>
    /// Prints all fields of an animal object who's id matches the player input
    /// Can also exclude certaint animal subclasses so long as animalType != null
    /// </summary>
    /// 
    //TODO make an overload of this method instead of using null
    //TODO this method does not support sub-types of animals
    public static Animal FindAnimalWithId(string? animalType)
    {
        if(animals.Count == 0)
        {
            Console.WriteLine("Database is empty\n"
            + "Press any key to continue...");
            Console.ReadKey(true);
        }
        PrintAllAnimals(false);
        int foundAnimalIndex;
        while (true)
        {
            Console.WriteLine("Enter an id to search for:");
            string idToSearch = IUtils.GetStringFromUser(false);
            foundAnimalIndex = animals.FindIndex(a => a.id.Equals(idToSearch));

            if (foundAnimalIndex != -1) // && (animalType == animals[foundAnimalIndex].GetType().ToString() || animalType == null)
            {
                Console.WriteLine($"Successfully found animal with Id {idToSearch}\n"
                + $"- Name: {animals[foundAnimalIndex].name}\n"
                + $"- Fur Color {animals[foundAnimalIndex].furColor}\n"
                + $"- Owner Name: {animals[foundAnimalIndex].owner.name}\n"
                + $"- - Owner Id: {animals[foundAnimalIndex].owner.id}");

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return animals[foundAnimalIndex];
            }
            else
            {
                Console.WriteLine("No animal with this id was found in the database");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                continue;
            }
        }
    }

    /// <summary>
    /// Finds and removes an animal object from the animals list given an id
    /// </summary>
    private static void RemoveAnimal()
    {
        Console.Clear();
        PrintAllAnimals(false);

        if(animals.Count == 0)
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }

        while(true)
        {
            Console.WriteLine("Please enter the identification number of the animal you wish to remove");

            string searchId = IUtils.GetStringFromUser(false);
            int animalIndex = animals.FindIndex(a => a.id.Equals(searchId));

            if(animalIndex != -1)
            {
                animals.RemoveAt(animalIndex);
                Console.WriteLine($"Successfully removed animal with id {searchId} from database");
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
    /// Add an instace of an animal object to the animals list according to user specifications
    /// </summary>
    private static void AddNewAnimal()
    {
        if(Person.people.Count == 0)
        {
            Console.WriteLine("There are no people in the person database\n"
            + "An animal must have an owner\n"
            + "Press any key to continue...");
            Console.ReadKey();
            return;
        }

        Console.Clear();
        Console.WriteLine("Enter the name of the animal");
        string name = IUtils.GetStringFromUser(true);

        Console.Clear();
        Console.WriteLine("Enter the id of the animal");
        string id = IUtils.GetStringFromUser(false);

        Console.Clear();
        Console.WriteLine("Enter the fur color of the animal");
        string furColor = IUtils.GetStringFromUser(false);

        Console.Clear();
        Console.WriteLine("Add an owner");
        Client owner = Person.FindPersonWithId(true);

        Console.Clear();

        //TODO use types better
        // Uses a series of enums to get subclass type


        /*
        if(methodInfo is null)
        {
            Console.WriteLine("null");
        }
        else
        {
            Console.WriteLine(methodInfo);
            Console.WriteLine(methodInfo.GetConstructors().Length);
        }
        */



        string coolType = "OrangeCat";
        Animal? o = (Animal?) Activator.CreateInstance(Type.GetType(coolType), new object[] { id, name, furColor, owner });

        if(o is null)
        {
            Console.WriteLine("Failed");
        }
        else
        {
            Console.WriteLine("Success");
            //animals.Add(o);
        }

        


        for (int i = 0; i < Enum.GetNames(typeof(AnimalTypes)).Length; i++)
        {
            Console.WriteLine($"{i + 1}: {Enum.GetName(typeof(AnimalTypes), i)}");
        }

        Console.WriteLine("Choose an animal type");

        {
            int answer = IUtils.GetIntFromUser(Enum.GetNames(typeof(AnimalTypes)).Length) - 1;

            Console.Clear();

            Type? animalType = Type.GetType(Enum.GetName(typeof(AnimalTypes), answer));
            Type? animalEnumType = animalType.GetNestedType(animalType.ToString() + "Types");
            
            /*
            
            if(animalTypeEnum is not null)
            {
                Console.WriteLine($"Type is {animalType}");
                Console.WriteLine(animalTypeEnum.IsEnum);
                Console.WriteLine(animalTypeEnum);
            }
            else
            {
                Console.WriteLine("Type is null");
            }
            */

            for (int i = 0; i < Enum.GetNames(animalEnumType).Length; i++)
            {
                Console.WriteLine($"{i + 1}: {Enum.GetName(animalEnumType, i)}");
            }
            Console.WriteLine("Choose an animal type");
            answer = IUtils.GetIntFromUser(Enum.GetNames(animalEnumType).Length);


        }

        /*
        switch(Enum.GetName(typeof(AnimalTypes), IUtils.GetIntFromUser(Enum.GetNames(typeof(AnimalTypes)).Length) - 1).ToString())
        {
            case "Dog":
                Console.Clear();
                for (int i = 0; i < Enum.GetNames(typeof(Dog.DogTypes)).Length; i++)
                {
                    Console.WriteLine($"{i + 1}: {Enum.GetName(typeof(Dog.DogTypes), i)}");
                }
                switch(Enum.GetName(typeof(Dog.DogTypes), IUtils.GetIntFromUser(Enum.GetNames(typeof(Dog.DogTypes)).Length) - 1).ToString())
                {
                    case "RedDog":
                        animals.Add(new RedDog(id, name, furColor, owner));
                        break;

                    case "YellowDog":
                        animals.Add(new YellowDog(id, name, furColor, owner));
                        break;
                }
                break;

            case "Cat":
                Console.Clear();
                for (int i = 0; i < Enum.GetNames(typeof(Cat.CatTypes)).Length; i++)
                {
                    Console.WriteLine($"{i + 1}: {Enum.GetName(typeof(Cat.CatTypes), i)}");
                }
                switch(Enum.GetName(typeof(Cat.CatTypes), IUtils.GetIntFromUser(Enum.GetNames(typeof(Cat.CatTypes)).Length) - 1).ToString())
                {
                    case "OrangeCat":
                        animals.Add(new OrangeCat(id, name, furColor, owner));
                        break;

                    case "PurpleCat":
                        animals.Add(new PurpleCat(id, name, furColor, owner));
                        break;

                    default:
                        Console.WriteLine("Not found");
                        break;
                }
                break;
        }
        */

        foreach(Animal animal in animals)
        {
            Console.WriteLine(animal.GetType());
        }

        Console.WriteLine("Successfully added animal to the database");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    /// <summary>
    /// Meow
    /// </summary>
    public abstract void MakeSound();
}