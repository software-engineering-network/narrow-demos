namespace LayeredCreation.Domain.Builder;

public interface IOrderRepository
{
    void Create(Order order);
    Order Find(Guid id);
}
