using FluentAssertions;

namespace ConsoleApps.ConsoleApp.Spec.SelectorViewModelSpec;

public class WhenInstantiating
{
    #region Setup

    private readonly List<Car> _cars = new()
    {
        new(Guid.NewGuid(), "Ford", "Mustang", 2015),
        new(Guid.NewGuid(), "Chevrolet", "Camaro", 2015)
    };

    private readonly SelectorViewModel<Car> _vm;

    public WhenInstantiating()
    {
        _vm = new SelectorViewModel<Car>(() => _cars);
    }

    #endregion

    #region Requirements

    [Fact]
    public void ThenPageIsSet() => _vm.Page.Should().Be(1);

    [Fact]
    public void ThenValuesAreNotEmpty() => _vm.Values.Should().HaveCount(2);

    #endregion
}
