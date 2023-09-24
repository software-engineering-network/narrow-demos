namespace ConsoleApps.Domain;

public abstract class Aggregate : Entity
{
    protected Aggregate(Guid id) : base(id)
    {
    }
}
