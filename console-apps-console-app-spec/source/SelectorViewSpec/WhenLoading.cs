namespace ConsoleApps.ConsoleApp.Spec.SelectorViewSpec;

public class WhenLoading
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
        //var vm = new CarSelectorViewModel(() => _cars);
        //var v = new SelectorView<Car>(vm);
    }

    #endregion
}
