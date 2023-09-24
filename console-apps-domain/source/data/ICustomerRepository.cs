namespace ConsoleApps.Domain;

public interface ICustomerRepository : IRepository<Customer>
{
    void Create(Customer car);
    Customer Find(Guid id);
}
