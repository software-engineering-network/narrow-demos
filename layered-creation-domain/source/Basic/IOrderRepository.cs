namespace LayeredCreation.Domain.Basic;

public interface IOrderRepository
{
    void Create(Order order);
    Order Find(Guid id);
}
