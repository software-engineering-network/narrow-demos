namespace Uow.Domain;

public abstract class Entity
{
    protected Entity()
    {
        Id = NewGuid();
    }

    protected Entity(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}
