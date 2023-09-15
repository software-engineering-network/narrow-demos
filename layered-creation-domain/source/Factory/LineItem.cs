namespace LayeredCreation.Domain.Factory;

public class LineItem : Entity
{
    public LineItem(Guid id, Guid orderId, string sku, decimal price, ushort quantity) : base(id)
    {
        OrderId = orderId;
        Price = price;
        Quantity = quantity;
        Sku = sku;
    }

    public LineItem(Guid orderId, string sku, decimal price, ushort quantity) : this(
        NewGuid(),
        orderId,
        sku,
        price,
        quantity
    )
    {
    }

    public Guid OrderId { get; }
    public decimal Price { get; }
    public ushort Quantity { get; }
    public string Sku { get; }
    public decimal Subtotal => Price * Quantity;
}
