abstract class Animal
{
    public string? furColor {get; set; }
    public string? name { get; set; }
    public int? idNumber { get; set; }
    public Person owner { get; set; }
    public Animal(int idNumber, Person owner)
    {
        this.idNumber = idNumber;
        this.owner = owner;
    }
}