namespace ConsoleApps.Infrastructure.InMemory;

public class SalespersonRepository : ISalespersonRepository
{
    private readonly Storage _storage;

    public SalespersonRepository(Storage storage)
    {
        _storage = storage;
    }

    public void Create(Salesperson salesperson)
    {
        _storage.Salespersons.Add(salesperson);
    }

    public Salesperson Find(Guid id) => _storage.Salespersons.Single(x => x.Id == id);
}
