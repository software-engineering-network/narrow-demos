using FluentAssertions;
using Uow.Domain;
using Uow.Infrastructure.Clients;
using Uow.Infrastructure.Clients.Pattern;
using Uow.Infrastructure.Venues.Pattern;
using Uow.Services;
using Uow.Services.Pattern;
using Customer = Uow.Domain.Customer;

namespace Uow.Spec.Pattern;

public class Fixture : IDisposable
{
    public IConcertRepository ConcertRepository;
    public ICustomerRepository CustomerRepository;
    public IReservationRepository ReservationRepository;
    public IUnitOfWork Uow;

    public Fixture()
    {
        var clientsContext = new Context();
        var venuesContext = new Infrastructure.Venues.Context();
        Uow = new UnitOfWork(clientsContext, venuesContext);
        ConcertRepository = new ConcertRepository(venuesContext);
        CustomerRepository = new CustomerRepository(clientsContext);
        ReservationRepository = new ReservationRepository(clientsContext);

        Concert = new Concert(2000);
        ConcertRepository.Create(Concert);

        Customer = new Customer("John", "Doe");
        CustomerRepository.Create(Customer);

        Uow.Commit();
    }

    public void Deconstruct(
        out IConcertRepository concertRepository,
        out ICustomerRepository customerRepository,
        out IReservationRepository reservationRepository,
        out IUnitOfWork uow,
        out Concert concert,
        out Customer customer
    )
    {
        concertRepository = ConcertRepository;
        customerRepository = CustomerRepository;
        reservationRepository = ReservationRepository;
        uow = Uow;
        concert = Concert;
        customer = Customer;
    }

    public Concert Concert { get; }
    public Customer Customer { get; }

    public void Dispose()
    {
        ConcertRepository.Delete(Concert.Id);
        CustomerRepository.Delete(Customer.Id);
        ReservationRepository.DeleteAll();
        Uow.Commit();
    }
}

public partial class WhenTicketsAreReserved : IClassFixture<Fixture>
{
    #region Setup

    private const int RequestedTickets = 4;
    private readonly Concert _concert;
    private readonly IConcertRepository _concertRepository;
    private readonly int _originalTickets;
    private readonly Guid _reservationId;
    private readonly IReservationRepository _reservationRepository;
    private readonly ITicketReservationService _service;
    private readonly IUnitOfWork _uow;

    public WhenTicketsAreReserved(Fixture fixture)
    {
        (_concertRepository, _, _reservationRepository, _uow, _concert, var customer) = fixture;

        _service = new TicketReservationService(_uow, _concertRepository, _reservationRepository);

        _originalTickets = _concertRepository.Find(_concert.Id).AvailableTickets;
        _reservationId = _service.Reserve(_concert.Id, customer.Id, 4);
    }

    #endregion

    #region Requirements

    [Fact]
    public void ThenReservationIsCreated()
    {
        _reservationRepository.Exists(_reservationId).Should().BeTrue();
    }

    [Fact]
    public void ThenTicketsAvailableAreUpdated()
    {
        var concert = _concertRepository.Find(_concert.Id);

        concert.AvailableTickets.Should().Be(_originalTickets - RequestedTickets);
    }

    #endregion
}
