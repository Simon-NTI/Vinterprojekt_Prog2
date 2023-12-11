abstract class Establishment
{
    private string location;
    private Animal animal;

    private List<Animal> animalsOnSite = new();

    protected Establishment(string location, Animal animal, List<Animal> animalsOnSite)
    {
        this.location = location;
        this.animal = animal;
        this.animalsOnSite = animalsOnSite;
    }


    public void appendNewAnimal()
    {
        
    }
}