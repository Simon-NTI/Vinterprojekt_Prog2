abstract class Person
{
    private string name;
    private string personalId;
    private List<Animal> pets = new List<Animal>();

    public Person(string name, string personalId)
    {
        this.name = name;
        this.personalId = personalId;
    }
}