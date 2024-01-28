abstract class Dog : Animal
{
    public enum DogTypes
    {
        RedDog,
        YellowDog
    }
    public Dog(string id, string name, string furColor, Person owner) : base(id, name, furColor, owner)
    {

    }
}