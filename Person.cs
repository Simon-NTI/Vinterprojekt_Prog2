
using System.Linq.Expressions;
using System.Reflection.Metadata;

abstract class Person
{
    //TODO change properties to reflect actual usage
    //TODO i.e remove set property from all fields that do not use it
    public static List<Person> people { get; set; } = new();
    public string name { get; set; }
    public string id { get; set; }
    public Person(string name, string id)
    {
        this.name = name;
        this.id = id;
    }

    //TODO a lot of methods in this class resemble methods in the Animal class
    //TODO find a way to make more generic methods if possible
    public static void HandlePeopleDatabase()
    {
        Console.Clear();
        Console.WriteLine("What do you wish to do?\n"
        + "1: View all people with name\n"
        + "2: View a person based on id \n"
        + "3: View all people in database\n"
        + "4: Remove a person from the database\n"
        + "5: Add a client to the database\n"
        + "6: Add a staff to the database");

        switch(Utils.GetIntFromUser(6))
        {
            case 1:
                FindPeopleWithName();
                break;

            case 2:
                Console.Clear();
                FindPersonWithId(false);
                break;

            case 3:
                Console.Clear();
                PrintAllPeople(true, false);
                break;
            
            case 4:
                RemovePerson();
                break;

            case 5:
                AddNewClient();
                break;
        }
    }

    //TODO expand methods to print pet information if the person is of type client
    private static void PrintAllPeople(bool pause, bool mustBeClient)
    {
        if(people.Count > 0)
        {
            if(mustBeClient)
            {
                foreach(Person person in people)
                {
                    if(person.GetType().ToString() == "Client")
                    {
                        Console.WriteLine($"Name: {person.name}\n"
                        + $"{person.GetType()}\n"
                        + $"- Id: {person.id}\n");
                    }
                }
            }
            else
            {
                foreach(Person person in people)
                {
                    Console.WriteLine($"Name: {person.name}\n"
                    + $"{person.GetType()}\n"
                    + $"- Id: {person.id}\n");
                }
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
    private static void FindPeopleWithName()
    {
        List<Person> foundPeople = new();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Enter a name to search for:");
            string nameToSearch = Utils.GetStringFromUser(true);
            foundPeople = people.FindAll(a => a.name.Equals(nameToSearch));

            if (foundPeople.Count > 0)
            {
                Console.WriteLine($"-- Found {foundPeople.Count} people with the name {nameToSearch} --");
                foreach(Person person in foundPeople)
                {
                    Console.WriteLine($"- Id: {person.id}\n");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("No people with this name was found in the database");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                continue;
            }
        }
    }
    public static Client FindPersonWithId(bool mustBeClient)
    {
        int foundPersonIndex;
        while (true)
        {
            if(mustBeClient)
            {
                PrintAllPeople(false, true);
            }
            else
            {
                PrintAllPeople(false, false);
            }
            Console.WriteLine("Enter an id to search for:");
            string idToSearch = Utils.GetStringFromUser(false);
            foundPersonIndex = people.FindIndex(a => a.id.Equals(idToSearch));

            if(mustBeClient && foundPersonIndex != -1)
            { 
                if(people[foundPersonIndex].GetType().ToString() != "Client")
                {
                    foundPersonIndex = -1;
                }
            }

            if (foundPersonIndex != -1)
            {
                Console.WriteLine($"Successfully found person with Id {idToSearch}, name: {people[foundPersonIndex].name}\n");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return (Client)people[foundPersonIndex];
            }
            else
            {
                Console.WriteLine("No people with this id was found in the database");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                continue;
            }
        }
    }
    private static void RemovePerson()
    {
        Console.Clear();
        PrintAllPeople(false, false);

        while(true)
        {
            Console.WriteLine("Please enter the identification number of the person you wish to remove");
            string searchId = Utils.GetStringFromUser(false);
            int personIndex = people.FindIndex(a => a.id.Equals(searchId));

            if(personIndex != -1)
            {
                people.RemoveAt(personIndex);
                Console.WriteLine($"Successfully removed person with id {searchId} from database");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("No person with this id was found");
                continue;
            }
        }
    }
    private static void AddNewClient()
    {
        Console.Clear();
        Console.WriteLine("Enter the name of the client");
        string name = Utils.GetStringFromUser(true);

        string id;
        while(true)
        {
            Console.Clear();
            Console.WriteLine("Enter the Id of the client");
            id = Utils.GetStringFromUser(false);

            if(people.FindIndex(a => a.id.Equals(id)) == -1)
            {
                break;
            }
            else
            {
                Console.WriteLine("A person with this id already exists in the database");
                continue;
            }
        }

        Console.Clear();
        List<Animal> animals = new();

        if(Animal.animals.Count == 0)
        {
            Console.Clear();
            people.Add(new Client(name, id, animals));
            Console.WriteLine("Successfully added client to database\n"
            + "Press any key to continue...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Does the client have pets?\n"
        + "1: Yes"
        + "2: No");


        //TODO print all animals in the animal database and let the user choose an animal from the list
        //TODO check for duplicates before adding it to the pets list
        while(true)
        {
            bool shouldContinue = true;
            switch(Utils.GetIntFromUser(2))
            {
                case 1:
                    Animal animal = Animal.FindAnimalWithId();
                    if(animals.FindIndex(a => a.id.Equals(animal.id)) == -1)
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
            + "1: Yes"
            + "2: No");

            switch(Utils.GetIntFromUser(2))
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

        Console.Clear();
        people.Add(new Client(name, id, animals));
        Console.WriteLine("Successfully added client to database");


    }

    private static void AddNewStaff()
    {

    }
}
