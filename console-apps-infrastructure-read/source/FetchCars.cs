using ConsoleApps.Domain;
using ConsoleApps.Infrastructure.InMemory;

namespace ConsoleApps.Infrastructure.Read;

public record FetchCars : Query;

public record Car(Guid Id, string Make, string Model, ushort Year)
{
    public static implicit operator Car(Domain.Car source) =>
        new(
            source.Id,
            source.Make,
            source.Model,
            source.Year
        );
}

public class FetchCarsHandler : Query.IHandler<FetchCars, IEnumerable<Car>>
{
    private readonly Storage _storage;

    public FetchCarsHandler(Storage storage)
    {
        _storage = storage;
    }

    public IEnumerable<Car> Handle(FetchCars query) => _storage.Cars.Select(x => (Car) x);
}
