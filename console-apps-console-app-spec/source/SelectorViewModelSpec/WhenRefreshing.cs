using ConsoleApps.Domain;
using ConsoleApps.Infrastructure.Read;
using FluentAssertions;

namespace ConsoleApps.ConsoleApp.Spec.SelectorViewModelSpec;

public class WhenRefreshing
{
    #region Setup

    private readonly SelectorViewModel<Car> _vm;

    public WhenRefreshing()
    {
        var handler = new MockFetchCarHandler();
        _vm = new SelectorViewModel<Car>(() => handler.Handle(new()));

        handler.Update();

        _vm.Refresh();
    }

    #endregion

    #region Requirements

    [Fact]
    public void ThenPageIsSet() => _vm.Page.Should().Be(1);

    [Fact]
    public void ThenValuesAreNotEmpty() => _vm.Values.Should().Contain(x => x.Model == "Camry");

    #endregion

    public class MockFetchCarHandler : Query.IHandler<FetchCars, IEnumerable<Car>>
    {
        private readonly List<Car> _cars = new()
        {
            new(Guid.NewGuid(), "Ford", "Mustang", 2015),
            new(Guid.NewGuid(), "Chevrolet", "Camaro", 2015)
        };

        public void Update()
        {
            _cars.Clear();
            _cars.Add(new(Guid.NewGuid(), "Toyota", "Camry", 2015));
        }

        public IEnumerable<Car> Handle(FetchCars query) => _cars;
    }
}
