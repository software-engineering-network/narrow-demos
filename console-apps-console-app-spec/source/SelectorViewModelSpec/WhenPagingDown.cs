using FluentAssertions;
using FluentAssertions.Execution;

namespace ConsoleApps.ConsoleApp.Spec.SelectorViewModelSpec;

public class WhenPagingDown
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

    public WhenPagingDown()
    {
        _vm = new SelectorViewModel<Car>(() => _cars)
            .NextPage()
            .PreviousPage();
    }

    #endregion

    #region Requirements

    [Fact]
    public void BeyondMinPage_ThenViewModelIsExpected()
    {
        using var scope = new AssertionScope();
        _vm.Page.Should().Be(1);
        _vm.Values.Should().NotContain(x => x == _cars.Last());
    }

    [Fact]
    public void ThenPageIsSet() => _vm.Page.Should().Be(1);

    [Fact]
    public void ThenValuesAreExpected() => _vm.Values.Should().NotContain(x => x == _cars.Last());

    #endregion
}
