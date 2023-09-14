using LayeredCreation.Domain.Factory;

namespace LayeredCreation.Services.Factory;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository;
    }

    public Guid Create(CreateOrder command)
    {
        var factoryMethods = command.LineItems
            .Select(
                x =>
                {
                    LineItem CreateLineItem(Guid orderId) => new(orderId, x.Sku, x.Price, x.Quantity);
                    return (Func<Guid, LineItem>) CreateLineItem;
                }
            )
            .ToArray();

        var order = new Order(factoryMethods);

        _repository.Create(order);

        return order.Id;
    }

    public OrderDto Find(Guid id) => _repository.Find(id);
}
