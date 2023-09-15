namespace LayeredCreation.Domain.Factory;

public class Order : Entity
{
    private readonly List<LineItem> _lineItems = new();

    public Order(params Func<Guid, LineItem>[] factories)
    {
        foreach (var f in factories)
            _lineItems.Add(f(Id));
    }

    public IReadOnlyList<LineItem> LineItems => _lineItems.AsReadOnly();
}
