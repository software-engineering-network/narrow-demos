using FluentAssertions;

namespace ConsoleApps.ConsoleApp.Spec.SelectorViewSpec;

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

    #endregion

    #region Requirements

    [Fact]
    public void ThenChoicesAreUpdated()
    {
        var vm = new SelectorViewModel<Car>(() => _cars);
        var v = new SelectorView<Car>(vm);

        vm.NextPage();

        vm.Values.Should().OnlyContain(x => x.Model == "Camry");
    }

    #endregion
}
