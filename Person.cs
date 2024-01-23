abstract class Person
{
    public static List<Person> people { get; set; } = new List<Person>();
    public string name { get; set; }
    public string personalId { get; set; }

    public Person(string name, string personalId)
    {
        this.name = name;
        this.personalId = personalId;
    }
}