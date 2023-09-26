namespace ConsoleApps.Domain;

public class Dealership : Aggregate
{
    public Dealership(string name) : this(
        NewGuid(),
        name
    )
    {
    }

    public Dealership(Guid id, string name) : base(id)
    {
        Name = name;
    }

    public string Name { get; }
}
