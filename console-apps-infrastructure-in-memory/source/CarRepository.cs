namespace ConsoleApps.Infrastructure.InMemory;

public class CarRepository : ICarRepository
{
    private readonly Storage _storage;

    public CarRepository(Storage storage)
    {
        _storage = storage;
    }

    public void Create(Car car)
    {
        _storage.Cars.Add(car);
    }

    public Car Find(Guid id) => _storage.Cars.Single(x => x.Id == id);
}
