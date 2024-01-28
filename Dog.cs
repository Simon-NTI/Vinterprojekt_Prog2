abstract class Dog : Animal
{
    public enum DogTypes
    {
        Borzoi,
        GoldenRetriever
    }
    public Dog(int idNumber, Person owner) : base(idNumber, owner)
    {

    }
}