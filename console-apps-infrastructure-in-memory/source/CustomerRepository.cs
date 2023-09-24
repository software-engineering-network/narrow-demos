namespace ConsoleApps.Infrastructure.InMemory;

public class CustomerRepository : ICustomerRepository
{
    private readonly Storage _storage;

    public CustomerRepository(Storage storage)
    {
        _storage = storage;
    }

    public void Create(Customer customer)
    {
        _storage.Customers.Add(customer);
    }

    public Customer Find(Guid id) => _storage.Customers.Single(x => x.Id == id);
}
