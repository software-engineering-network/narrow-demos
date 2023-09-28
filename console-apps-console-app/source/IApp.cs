using ConsoleApps.ConsoleApp;
using ConsoleApps.Domain;
using ConsoleApps.Infrastructure.Read;
using Car = ConsoleApps.ConsoleApp.Car;
using ReadCar = ConsoleApps.Infrastructure.Read.Car;

public interface IApp
{
    void Run();
}

public class App : IApp
{
    private readonly SelectorViewModel<Car> _carViewModel;
    private readonly bool _isRunning = true;
    private readonly List<IView> _views = new();

    public App(Query.IHandler<FetchCars, IEnumerable<ReadCar>> fetchCarsHandler)
    {
        _carViewModel = new(() => fetchCarsHandler.Handle(new()).Select(x => (Car) x));
        _views.Add(new SelectorView<Car>(_carViewModel));
    }

    public void Run()
    {
        while (_isRunning)
        {
            foreach (var view in _views)
                view.Print();

            Console.ReadKey();
        }
    }
}
