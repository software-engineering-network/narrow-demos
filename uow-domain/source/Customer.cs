namespace Uow.Domain;

public class Customer : Entity
{
    public Customer(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public Customer(Guid id, string firstName, string lastName) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; }
    public string LastName { get; }
}

public interface ICustomerRepository
{
    void Create(Customer customer);
    void Delete(Guid id);
}
