namespace Administration.Models;

public record Airport
{
    public string Name { get; private set; }
    
    public Airport(string name)
    {
        Name = name;
    }
}