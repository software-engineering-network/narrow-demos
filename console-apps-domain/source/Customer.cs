namespace ConsoleApps.Domain;

public class Customer : Entity
{
    public Customer(string name, string surname) : this(
        NewGuid(),
        name,
        surname
    )
    {
    }

    public Customer(Guid id, string name, string surname) : base(id)
    {
        Name = name;
        Surname = surname;
    }

    public string Name { get; }
    public string Surname { get; }
}
