class Client : Person 
{
    public List<Animal> pets { get; set; } = new List<Animal>();
    public Client(string name, string personalId) : base(name, personalId)
    {

    }
}