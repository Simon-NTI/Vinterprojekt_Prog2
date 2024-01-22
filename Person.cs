abstract class Person
{
    public string name { get; set; }
    public string personalId { get; set; }
    private List<Animal> pets = new List<Animal>();

    public Person(string name, string personalId)
    {
        this.name = name;
        this.personalId = personalId;
    }
}