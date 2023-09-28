using FluentAssertions;
using FluentAssertions.Execution;

namespace ConsoleApps.ConsoleApp.Spec.SelectorViewModelSpec;

public class WhenPagingUp
{
    #region Setup

    private readonly List<Car> _cars = new()
    {
        new(Guid.NewGuid(), "Ford", "Mustang", 2015),
        new(Guid.NewGuid(), "Chevrolet", "Camaro", 2015),
        new(Guid.NewGuid(), "Chevrolet", "Camaro", 2015),
        new(Guid.NewGuid(), "Chevrolet", "Camaro", 2015),
        new(Guid.NewGuid(), "Chevrolet", "Camaro", 2015),
        new(Guid.NewGuid(), "Chevrolet", "Camaro", 2015),
        new(Guid.NewGuid(), "Chevrolet", "Camaro", 2015),
        new(Guid.NewGuid(), "Chevrolet", "Camaro", 2015),
        new(Guid.NewGuid(), "Chevrolet", "Camaro", 2015),
        new(Guid.NewGuid(), "Chevrolet", "Camaro", 2015),
        new(Guid.NewGuid(), "Toyota", "Camry", 2015)
    };

    private readonly SelectorViewModel<Car> _vm;

    public WhenPagingUp()
    {
        _vm = new SelectorViewModel<Car>(() => _cars);
        _vm.NextPage();
    }

    #endregion

    #region Requirements

    [Fact]
    public void BeyondMaxPage_ThenViewModelIsExpected()
    {
        _vm.NextPage();

        using var scope = new AssertionScope();
        _vm.Page.Should().Be(2);
        _vm.Values.Should().OnlyContain(x => x == _cars.Last());
    }

    [Fact]
    public void ThenPageIsSet() => _vm.Page.Should().Be(2);

    [Fact]
    public void ThenValuesAreExpected() => _vm.Values.Should().OnlyContain(x => x == _cars.Last());

    #endregion
}
