namespace ConsoleApps.ConsoleApp;

public record Car(Guid Id, string Make, string Model, ushort Year)
{
    public override string ToString() => $"{Year} {Make} {Model}";

    public static implicit operator Car(Infrastructure.Read.Car source) =>
        new(
            source.Id,
            source.Make,
            source.Model,
            source.Year
        );
}
