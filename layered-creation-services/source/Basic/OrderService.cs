using LayeredCreation.Domain.Basic;

namespace LayeredCreation.Services.Basic;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository;
    }

    public override string ToString() => "basic order service";

    public Guid Create(CreateOrder command)
    {
        var order = new Order();

        foreach (var (sku, price, quantity) in command.LineItems)
            order.Add(sku, price, quantity);

        _repository.Create(order);

        return order.Id;
    }

    public OrderDto Find(Guid id) => _repository.Find(id);
}
