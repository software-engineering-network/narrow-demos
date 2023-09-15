namespace LayeredCreation.Services;

public interface IOrderService
{
    public Guid Create(CreateOrder command);
    public OrderDto Find(Guid id);
}
