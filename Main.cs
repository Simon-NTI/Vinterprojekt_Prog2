using System.Runtime.CompilerServices;

namespace Vinterprojekt_Prog2;

class Program
{
    static void Main(string[] args)
    {
        List<Client> clients = new List<Client>
        {
            new("Peter", "74"),
            new("Jeff", "52"),
            new("Sean", "15")
        };

        Console.WriteLine("What do you want to do?: ");
        Console.WriteLine("1: View or modify hotels\n",
        "2: View or modify daycares\n",
        "3: View or modify boardings\n");

        switch(Utils.GetIntFromUser())
        {
            case 1:

                break;
        }
    }
}