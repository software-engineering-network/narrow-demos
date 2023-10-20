using Uow.Domain;

namespace Uow.Infrastructure.Clients.Pattern;

public class CustomerRepository : ICustomerRepository
{
    private readonly Context _context;

    public CustomerRepository(Context context)
    {
        _context = context;
    }

    public void Create(Domain.Customer customer)
    {
        _context.Customer.Add(customer);
    }

    public void Delete(Guid id)
    {
        var customer = _context.Customer.Find(id);
        _context.Customer.Remove(customer);
    }
}
