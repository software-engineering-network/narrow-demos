using ConsoleApps.Domain;
using ConsoleApps.Infrastructure.Read;

namespace ConsoleApps.ConsoleApp;

public interface IMenuItem
{
}

public interface IDataSet
{
    IMenuItem Get(int index);
    IEnumerable<IMenuItem> Get();
    void Refresh();
}

public abstract class DataSet : IDataSet
{
    public abstract IMenuItem Get(int index);
    public abstract IEnumerable<IMenuItem> Get();
    public abstract void Refresh();
}

public record Car(Guid Id, string DisplayString) : IMenuItem
{
    public static implicit operator Car(Infrastructure.Read.Car source) =>
        new(
            source.Id,
            $@"{source.Year} {source.Make} {source.Model}"
        );
}

public class Menu
{
    private IDataSet _dataSet;

    public IReadOnlyList<IMenuItem> Choices => _dataSet.Get().ToList();

    public void Load(IDataSet dataSet)
    {
        _dataSet = dataSet;
    }

    public IMenuItem Select(int index) => _dataSet.Get(index);
}

public class CarDataSet : DataSet
{
    private readonly List<Car> _cars = new();
    private readonly Query.IHandler<FetchCars, IEnumerable<Infrastructure.Read.Car>> _handler;

    public CarDataSet(Query.IHandler<FetchCars, IEnumerable<Infrastructure.Read.Car>> handler)
    {
        _handler = handler;
        Refresh();
    }

    public override IMenuItem Get(int index) => _cars[index];
    public override IEnumerable<IMenuItem> Get() => _cars;

    public override void Refresh()
    {
        _cars.Clear();

        var cars = _handler.Handle(new());

        _cars.AddRange(cars.Select(x => (Car) x));
    }
}
