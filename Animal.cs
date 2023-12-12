abstract class Animal
{
    private string? furColor, name;
    private int? idNumber;
    private Person owner;
    public Animal(int idNumber, Person owner)
    {
        this.idNumber = idNumber;
        this.owner = owner;
    }
}