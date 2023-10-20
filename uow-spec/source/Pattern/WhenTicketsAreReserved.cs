using FluentAssertions;
using Uow.Domain;
using Uow.Infrastructure.Clients;
using Uow.Services;
using Uow.Services.Pattern;
using Customer = Uow.Domain.Customer;
using UnitOfWork = Uow.Infrastructure.Clients.Pattern.Uow;

namespace Uow.Spec.Pattern;

public class Fixture : IDisposable
{
    public IUow Uow;

    public Fixture()
    {
        var clientsContext = new Context();
        var venuesContext = new Infrastructure.Venues.Context();

        Uow = new UnitOfWork(clientsContext, venuesContext);

        Concert = new Concert(2000);
        Uow.Concerts.Create(Concert);

        Customer = new Customer("John", "Doe");
        Uow.Customers.Create(Customer);

        Uow.Commit();
    }

    public void Deconstruct(
        out IUow uow,
        out Concert concert,
        out Customer customer
    )
    {
        uow = Uow;
        concert = Concert;
        customer = Customer;
    }

    public Concert Concert { get; }
    public Customer Customer { get; }

    public void Dispose()
    {
        Uow.Concerts.Delete(Concert.Id);
        Uow.Customers.Delete(Customer.Id);
        Uow.Reservations.DeleteAll();
    }
}

public partial class WhenTicketsAreReserved : IClassFixture<Fixture>
{
    #region Setup

    private const int RequestedTickets = 4;
    private readonly Concert _concert;
    private readonly int _originalTickets;
    private readonly Guid _reservationId;
    private readonly ITicketReservationService _service;
    private readonly IUow _uow;

    public WhenTicketsAreReserved(Fixture fixture)
    {
        (_uow, _concert, var customer) = fixture;

        _service = new TicketReservationService(_uow);

        _originalTickets = _uow.Concerts.Find(_concert.Id).AvailableTickets;
        _reservationId = _service.Reserve(_concert.Id, customer.Id, 4);
    }

    #endregion

    #region Requirements

    [Fact]
    public void ThenReservationIsCreated()
    {
        _uow.Reservations.Exists(_reservationId).Should().BeTrue();
    }

    [Fact]
    public void ThenTicketsAvailableAreUpdated()
    {
        var concert = _uow.Concerts.Find(_concert.Id);

        concert.AvailableTickets.Should().Be(_originalTickets - RequestedTickets);
    }

    #endregion
}
