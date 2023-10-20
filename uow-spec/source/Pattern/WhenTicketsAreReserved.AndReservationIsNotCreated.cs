using FluentAssertions;
using Uow.Domain;
using Uow.Services;
using Uow.Services.Pattern;

namespace Uow.Spec.Pattern;

public partial class WhenTicketsAreReserved
{
    public class AndReservationIsNotAdded : IClassFixture<Fixture>
    {
        #region Setup

        private const int RequestedTickets = 4;
        private readonly Concert _concert;
        private readonly IConcertRepository _concertRepository;
        private readonly int _originalTickets;
        private readonly ITicketReservationService _service;
        private readonly IUow _uow;

        public AndReservationIsNotAdded(Fixture fixture)
        {
            (_, _concert, var customer) = fixture;

            _service = new TicketReservationService(
                new UowWithBrokenReservationRepository(new(), new())
            );

            _originalTickets = _concertRepository.Find(_concert.Id).AvailableTickets;
            var reservationId = _service.Reserve(_concert.Id, customer.Id, RequestedTickets);
        }

        #endregion

        #region Requirements

        [Fact]
        public void ThenTicketsAvailableAreNotUpdated()
        {
            var concert = _concertRepository.Find(_concert.Id);

            concert.AvailableTickets.Should().Be(_originalTickets);
        }

        #endregion
    }
}
