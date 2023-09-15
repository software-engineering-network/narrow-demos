using LayeredCreation.Domain.Builder;

namespace LayeredCreation.Services.Builder;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository;
    }

    public override string ToString() => "order service w/builder";

    public Guid Create(CreateOrder command)
    {
        var order = new OrderBuilder()
            .Load(command.LineItems)
            .Build()
            .GetOrder();

        _repository.Create(order);

        return order.Id;
    }

    public OrderDto Find(Guid id) => _repository.Find(id);
}

public class OrderBuilder : Order.Builder
{
    private readonly List<CandidateLineItem> _lineItems = new();
    private IEnumerator<CandidateLineItem> _enumerator;

    public override void AddLineItem()
    {
        var (sku, price, quantity) = _enumerator.Current;

        Order.Add(sku, price, quantity);
    }

    public override bool HasLineItem() => _enumerator.MoveNext();

    public OrderBuilder Load(IEnumerable<CandidateLineItem> lineItems)
    {
        _lineItems.AddRange(lineItems);
        _enumerator = _lineItems.GetEnumerator();
        return this;
    }
}
