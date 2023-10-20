namespace Uow.Infrastructure.Clients;

public class Customer : Entity
{
    public Customer()
    {
    }

    public Customer(Domain.Customer source) : base(source.Id)
    {
        FirstName = source.FirstName;
        LastName = source.LastName;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public static implicit operator Customer(Domain.Customer source) => new(source);
}
