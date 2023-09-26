using ConsoleApps.Domain;
using ConsoleApps.Infrastructure.Read;
using FluentAssertions;

namespace ConsoleApps.ConsoleApp.Spec;

public class MockFetchCarHandler : Query.IHandler<FetchCars, IEnumerable<Infrastructure.Read.Car>>
{
    public IEnumerable<Infrastructure.Read.Car> Handle(FetchCars query) =>
        new List<Infrastructure.Read.Car>
        {
            new(Guid.NewGuid(), "Ford", "Mustang", 2015),
            new(Guid.NewGuid(), "Chevrolet", "Camaro", 2015)
        };
}

public class WhenLoadingAMenu
{
    #region Implementation

    public static IEnumerable<object[]> GetDatasets()
    {
        yield return new object[] { new CarDataSet(new MockFetchCarHandler()) };
    }

    #endregion

    #region Requirements

    // IDataSet, ISelectable, IMenuItem
    // Menu, App, Screen

    /*
     * IDataSet<ISelectable>
     *
     * GetPage(int pageNumber); // gets 1-10, 11-20, 21-30
     * GetSelectable(i)
     *
     *
     * ISelectable
     * GetDisplayString();
     *   e.g. 2015 Ford Mustang
     *
     *
     * Menu
     *   Select(i) index
     *
     * Is a menu a view?
     */

    [Theory]
    [MemberData(nameof(GetDatasets))]
    public void Test1(IDataSet dataSet)
    {
        var menu = new Menu();

        menu.Load(dataSet);

        menu.Choices.Should().HaveCount(2);
    }

    [Theory]
    [MemberData(nameof(GetDatasets))]
    public void ThenSelectedMenuItemIsReturned(IDataSet dataSet)
    {
        var menu = new Menu();

        menu.Load(dataSet);

        var selectedItem = menu.Select(1);

        selectedItem.Should().NotBeNull();
    }

    #endregion
}
