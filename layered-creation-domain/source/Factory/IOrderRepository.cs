namespace LayeredCreation.Domain.Factory;

public interface IOrderRepository
{
    void Create(Order order);
    Order Find(Guid id);
}
