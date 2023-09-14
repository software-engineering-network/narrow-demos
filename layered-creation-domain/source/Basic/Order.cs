namespace LayeredCreation.Domain.Basic;

public class Order : Entity
{
    private readonly List<LineItem> _lineItems = new();

    public IReadOnlyList<LineItem> LineItems => _lineItems.AsReadOnly();

    public void Add(string sku, decimal price, ushort quantity)
    {
        _lineItems.Add(new(Id, sku, price, quantity));
    }
}
