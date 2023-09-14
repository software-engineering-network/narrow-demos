namespace LayeredCreation.Domain.Builder;

public class Order : Entity
{
    private readonly List<LineItem> _lineItems = new();

    private Order()
    {
    }

    public IReadOnlyList<LineItem> LineItems => _lineItems.AsReadOnly();

    public void Add(string sku, decimal price, ushort quantity)
    {
        _lineItems.Add(new(Id, sku, price, quantity));
    }

    public abstract class Builder
    {
        protected readonly Order Order = new();

        public abstract void AddLineItem();

        public Builder Build()
        {
            while (HasLineItem())
                AddLineItem();

            return this;
        }

        public Order GetOrder() => Order;
        public abstract bool HasLineItem();
    }
}
