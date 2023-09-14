namespace LayeredCreation.Domain.Builder;

public class Order : Entity
{
    private readonly List<LineItem> _lineItems = new();

    private Order()
    {
    }

    public IReadOnlyList<LineItem> LineItems => _lineItems.AsReadOnly();

    public void Add(LineItem lineItem)
    {
        _lineItems.Add(lineItem);
    }

    public abstract class Builder
    {
        protected readonly Order Order = new();

        public Builder Build()
        {
            while (HasLineItem())
                Order.Add(CreateLineItem());

            return this;
        }

        public abstract LineItem CreateLineItem();

        public Order GetOrder() => Order;
        public abstract bool HasLineItem();
    }
}
