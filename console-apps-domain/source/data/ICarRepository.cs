namespace ConsoleApps.Domain;

public interface ICarRepository : IRepository<Car>
{
    void Create(Car car);
    Car Find(Guid id);
}

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
