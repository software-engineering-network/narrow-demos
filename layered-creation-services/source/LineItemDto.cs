using LayeredCreation.Domain.Basic;

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
    public static implicit operator LineItemDto(LineItem source) =>
        new(
            source.Id,
            source.OrderId,
            source.Sku,
            source.Price,
            source.Quantity,
            source.Subtotal
        );

    public static implicit operator LineItemDto(Domain.Builder.LineItem source) =>
        new(
            source.Id,
            source.OrderId,
            source.Sku,
            source.Price,
            source.Quantity,
            source.Subtotal
        );

    public static implicit operator LineItemDto(Domain.Factory.LineItem source) =>
        new(
            source.Id,
            source.OrderId,
            source.Sku,
            source.Price,
            source.Quantity,
            source.Subtotal
        );
}
