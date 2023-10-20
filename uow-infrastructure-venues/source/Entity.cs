using System.ComponentModel.DataAnnotations.Schema;

namespace Uow.Infrastructure.Venues;

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

    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }
}
