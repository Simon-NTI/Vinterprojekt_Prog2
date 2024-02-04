/// <summary>
/// Contains information about Dogs of type RedDog
/// </summary>
class RedDog : Dog
{
    public RedDog(string id, string name, string furColor, Person owner) : base(id, name, furColor, owner)
    {
        
    }
    public override void MakeSound()
    {
        Console.WriteLine("Woof");
    }
}