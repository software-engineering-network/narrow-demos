using FluentAssertions;

namespace ConsoleApps.ConsoleApp.Spec.SelectorViewModelSpec;

public class WhenMakingASelection
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

    public WhenMakingASelection()
    {
        _vm = new SelectorViewModel<Car>(() => _cars);
    }

    #endregion

    #region Requirements

    [Fact]
    public void OnDifferentPage_ThenSelectionIsExpected()
    {
        _vm.NextPage().TrySelect(0, out var selection);

        selection.Should().Be(_cars.First(x => x.Model == "Camry"));
    }

    [Fact]
    public void ThenSelectionIsExpected()
    {
        _vm.TrySelect(0, out var selection);

        selection.Should().Be(_cars[0]);
    }

    [Fact]
    public void WithoutCorrespondingIndex_ThenDoNothing()
    {
        var isSuccessful = _vm.NextPage().TrySelect(1, out var selection);

        isSuccessful.Should().BeFalse();
    }

    #endregion
}
