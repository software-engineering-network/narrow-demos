namespace ConsoleApps.Domain;

public class Car : Aggregate
{
    public Car(string make, string model, ushort year) : this(
        NewGuid(),
        make,
        model,
        year
    )
    {
    }

    public Car(Guid id, string make, string model, ushort year) : base(id)
    {
        Make = make;
        Model = model;
        Year = year;
    }

    public string Make { get; }
    public string Model { get; }
    public ushort Year { get; }
}
