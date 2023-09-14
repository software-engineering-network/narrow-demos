namespace LayeredCreation.Services;

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
