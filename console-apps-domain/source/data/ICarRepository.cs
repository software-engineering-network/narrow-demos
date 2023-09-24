namespace ConsoleApps.Domain;

public interface ICarRepository : IRepository<Car>
{
    void Create(Car car);
    Car Find(Guid id);
}
