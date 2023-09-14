using LayeredCreation.Domain.Builder;

namespace LayeredCreation.Spec.Builder;

public class MockOrderRepository : IOrderRepository
{
    private readonly Dictionary<Guid, Order> _orders = new();

    public void Create(Order order) => _orders.Add(order.Id, order);

    public Order Find(Guid id) => _orders[id];
}
