class Client : Person 
{
    public List<Animal> pets { get; set; } = new List<Animal>();
    public Client(string name, string id, List<Animal> pets) : base(name, id)
    {
        this.pets = pets;
    }
}