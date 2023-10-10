using ConsoleApps.Domain;
using ConsoleApps.Infrastructure.Read;

namespace ConsoleApps.ConsoleApp;

public class CarSelector : IApp
{
    private readonly CarSelectorViewModel _carSelectorVm;
    private readonly IView _view;

    public CarSelector(CarSelectorViewModel carSelectorVm)
    {
        _carSelectorVm = carSelectorVm;

        _view = new CompositeView(
            new SelectorView<Car>(_carSelectorVm)
        );
    }

    public void Run()
    {
        throw new NotImplementedException();
    }
}

public class CarSelectorViewModel : SelectorViewModel<Car>
{
    public CarSelectorViewModel(Query.IHandler<FetchCars, IEnumerable<Car>> fetchCarsHandler)
    {
        _pageable.Load(
            fetchCarsHandler.Handle(new())
                .ToList()
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .ThenByDescending(x => x.Year)
        );
    }
}
