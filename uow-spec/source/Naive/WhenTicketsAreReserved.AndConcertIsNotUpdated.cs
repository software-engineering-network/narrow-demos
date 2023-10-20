using FluentAssertions;
using Uow.Domain;
using Uow.Services;
using Uow.Services.Naive;

namespace Uow.Spec.Naive;

public partial class WhenTicketsAreReserved
{
    public class AndConcertIsNotUpdated : IClassFixture<Fixture>
    {
        #region Setup

        private const int RequestedTickets = 4;
        private readonly Concert _concert;
        private readonly Guid _reservationId;
        private readonly IReservationRepository _reservationRepository;
        private readonly ITicketReservationService _service;

        public AndConcertIsNotUpdated(Fixture fixture)
        {
            (_, _, _reservationRepository, _concert, var customer) = fixture;

            _service = new TicketReservationService(new BrokenConcertRepository(), _reservationRepository);

            _reservationId = _service.Reserve(_concert.Id, customer.Id, RequestedTickets);
        }

        #endregion

        #region Requirements

        [Fact]
        public void ThenReservationIsRolledBack()
        {
            _reservationRepository.Exists(_reservationId).Should().BeFalse();
        }

        #endregion
    }
}
