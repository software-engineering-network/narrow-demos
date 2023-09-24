namespace ConsoleApps.Domain;

public class Salesperson : Entity
{
    public Salesperson(string name, string surname) : this(
        NewGuid(),
        name,
        surname
    )
    {
    }

    public Salesperson(Guid id, string name, string surname) : base(id)
    {
        Name = name;
        Surname = surname;
    }

    public string Name { get; }
    public string Surname { get; }
}
