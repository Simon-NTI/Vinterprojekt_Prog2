/// <summary>
/// Contains information about Animals of type Cat
/// </summary>
abstract class Cat : Animal
{
    public enum CatTypes
    {
        OrangeCat,
        PurpleCat
    }
    public Cat(string id, string name, string furColor, Person owner) : base(id, name, furColor, owner)
    {

    }
}