abstract class Person
{
    private string name;
    private int personalId;
    private List<Animal> pets = new List<Animal>();

    public Person(string name, int personalId)
    {
        this.name = name;
        this.personalId = personalId;
    }
}