using FluentAssertions;
using FluentAssertions.Execution;

namespace ConsoleApps.Domain.Spec;

public class WhenMakingASale
{
    #region Setup

    private readonly Car _car = new("Ford", "Mustang", 2015);
    private readonly Customer _customer = new("Joey", "Logano");
    private readonly Dealership _dealership = new("Columbus Ford");
    private readonly decimal _price = 23999.99m;
    private readonly Sale _sale;
    private readonly Salesperson _salesperson = new("John", "Doe");

    public WhenMakingASale()
    {
        var service = new SalesService();

        _sale = service.MakeSale(_car, _customer, _dealership, _salesperson, _price);
    }

    #endregion

    #region Requirements

    [Fact]
    public void ThenSaleIsExpected()
    {
        using var scope = new AssertionScope();

        _sale.CarId.Should().Be(_car.Id);
        _sale.CustomerId.Should().Be(_customer.Id);
        _sale.DealershipId.Should().Be(_dealership.Id);
        _sale.SalespersonId.Should().Be(_salesperson.Id);
        _sale.Price.Should().Be(_price);
    }

    #endregion
}
