namespace ConsoleApps.Domain;

public interface ISaleRepository : IRepository<Sale>
{
    void Create(Sale sale);
    Sale Find(Guid id);
}

public class SaleRepository : ISaleRepository
{
    private readonly Storage _storage;

    public SaleRepository(Storage storage)
    {
        _storage = storage;
    }

    public void Create(Sale sale)
    {
        _storage.Sales.Add(sale);
    }

    public Sale Find(Guid id) => _storage.Sales.Single(x => x.Id == id);
}
