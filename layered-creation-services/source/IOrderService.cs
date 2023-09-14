using LayeredCreation.Domain.Basic;

namespace LayeredCreation.Services;

public interface IOrderService
{
    public Guid Create(CreateOrder command);
    public OrderDto Find(Guid id);
}

public record OrderDto(
    Guid Id,
    IReadOnlyList<LineItemDto> LineItems
)
{
    public static implicit operator OrderDto(Order source) =>
        new(
            source.Id,
            source.LineItems.Select(x => (LineItemDto) x).ToList()
        );
}

public record LineItemDto(
    Guid Id,
    Guid OrderId,
    string Sku,
    decimal Price,
    ushort Quantity,
    decimal Subtotal
)
{
    public static implicit operator LineItemDto(Domain.Basic.LineItem source) =>
        new(
            source.Id,
            source.OrderId,
            source.Sku,
            source.Price,
            source.Quantity,
            source.Subtotal
        );
}
