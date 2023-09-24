namespace ConsoleApps.Domain;

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

    public static bool operator ==(Entity? left, Entity? right)
    {
        if (left is null)
            return right is null;

        return Equals(left, right);
    }

    public static bool operator !=(Entity? left, Entity? right) => !(left == right);

    #region Equality

    public override bool Equals(object? other)
    {
        if (other is null || GetType() != other.GetType())
            return false;

        return Equals((Entity) other);
    }

    protected bool Equals(Entity other) => Id.Equals(other.Id);

    public override int GetHashCode() => Id.GetHashCode();

    #endregion
}
