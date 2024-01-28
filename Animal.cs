using System.Runtime.CompilerServices;
using System.Security.Cryptography;

abstract class Animal
{
    public static List<Animal> animals { get; } = new();
    public string? furColor {get; }
    public string name { get; }
    public string id { get; }
    public Person owner { get; }
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

    public static void HandleAnimalsDatabase()
    {
        Console.Clear();
        Console.WriteLine("What do you wish to do?\n"
        + "1: View all animals with name\n"
        + "2: View an animal based on id \n"
        + "3: View all animals in database\n"
        + "4: Remove an animal from the database\n"
        + "5: Add an animal to the database");

        switch(Utils.GetIntFromUser(5))
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

    private static void PrintAllAnimals(bool pause)
    {
        Console.Clear();
        if(animals.Count > 0)
        {
            foreach(Animal animal in animals)
            {
                Console.WriteLine($"Id: {animal.id}\n"
                + $"- Name: {animal.name}\n"
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
    private static void FindAnimalsWithName()
    {
        List<Animal> foundAnimals = new();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Enter a name to search for:");
            string nameToSearch = Utils.GetStringFromUser(true);
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

   
    //TODO make an overload of this method instead of using null
    public static Animal FindAnimalWithId(string? animalType)
    {
        PrintAllAnimals(false);
        int foundAnimalIndex;
        while (true)
        {
            Console.WriteLine("Enter an id to search for:");
            string idToSearch = Utils.GetStringFromUser(false);
            foundAnimalIndex = animals.FindIndex(a => a.id.Equals(idToSearch));

            if (foundAnimalIndex != -1 && (animalType == animals[foundAnimalIndex].GetType().ToString() || animalType == null))
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
    private static void RemoveAnimal()
    {
        Console.Clear();
        PrintAllAnimals(false);

        while(true)
        {
            Console.WriteLine("Please enter the identification number of the animal you wish to remove");

            string searchId = Utils.GetStringFromUser(false);
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
        string name = Utils.GetStringFromUser(true);

        Console.Clear();
        Console.WriteLine("Enter the id of the animal");
        string id = Utils.GetStringFromUser(false);

        Console.Clear();
        Console.WriteLine("Enter the fur color of the animal");
        string furColor = Utils.GetStringFromUser(false);

        Console.Clear();
        Console.WriteLine("Add an owner");
        Client owner = Person.FindPersonWithId(true);

        Console.Clear();

        for (int i = 0; i < Enum.GetNames(typeof(AnimalTypes)).Length; i++)
        {
            Console.WriteLine($"{i + 1}: {Enum.GetName(typeof(AnimalTypes), i)}");
        }
        Console.WriteLine("Choose an animal type");

        switch(Enum.GetName(typeof(AnimalTypes), Utils.GetIntFromUser(Enum.GetNames(typeof(AnimalTypes)).Length) - 1).ToString())
        {
            case "Dog":
                Console.Clear();
                for (int i = 0; i < Enum.GetNames(typeof(Dog.DogTypes)).Length; i++)
                {
                    Console.WriteLine($"{i + 1}: {Enum.GetName(typeof(Dog.DogTypes), i)}");
                }
                switch(Enum.GetName(typeof(Dog.DogTypes), Utils.GetIntFromUser(Enum.GetNames(typeof(Dog.DogTypes)).Length) - 1).ToString())
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
                switch(Enum.GetName(typeof(Cat.CatTypes), Utils.GetIntFromUser(Enum.GetNames(typeof(Cat.CatTypes)).Length) - 1).ToString())
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

        Console.WriteLine("Successfully added animal to the database");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}