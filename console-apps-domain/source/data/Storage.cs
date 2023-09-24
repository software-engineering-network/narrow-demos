namespace ConsoleApps.Domain;

public class Storage
{
    public List<Car> Cars { get; } = new();
    public List<Customer> Customers { get; } = new();
    public List<Dealership> Dealerships { get; } = new();
    public List<Sale> Sales { get; } = new();
    public List<Salesperson> Salespersons { get; } = new();
}
