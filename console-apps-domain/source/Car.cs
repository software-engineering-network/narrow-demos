namespace ConsoleApps.Domain;

public class Car : Entity
{
    public Car(string make, string model, uint year) : this(
        NewGuid(),
        make,
        model,
        year
    )
    {
    }

    public Car(Guid id, string make, string model, uint year) : base(id)
    {
        Make = make;
        Model = model;
        Year = year;
    }

    public string Make { get; }
    public string Model { get; }
    public uint Year { get; }
}
