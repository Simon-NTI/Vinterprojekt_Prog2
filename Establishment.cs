abstract class Establishment
{
    private string location;
    private string animal;
    private List<Animal>? animalsOnSite = new();

    protected Establishment(string location, string animal)
    {
        this.location = location;
        this.animal = animal;
    }

    public void appendNewAnimal(Animal submittedAnimal)
    {
        
    }
}