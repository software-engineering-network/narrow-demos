using LayeredCreation.Domain.Basic;

namespace LayeredCreation.Services;

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
