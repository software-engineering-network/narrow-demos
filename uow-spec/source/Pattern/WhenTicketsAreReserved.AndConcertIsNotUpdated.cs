using FluentAssertions;
using Uow.Domain;
using Uow.Services.Pattern;

namespace Uow.Spec.Pattern;

public partial class WhenTicketsAreReserved
{
    public class AndConcertIsNotUpdated : IClassFixture<Fixture>
    {
        #region Setup

        private const int RequestedTickets = 4;
        private readonly Concert _concert;
        private readonly int _originalTickets;
        private readonly Guid _reservationId;
        private readonly IReservationRepository _reservationRepository;
        private readonly IUnitOfWork _uow;

        public AndConcertIsNotUpdated(Fixture fixture)
        {
            (_, _, _reservationRepository, _uow, _concert, var customer) = fixture;

            var service = new TicketReservationService(_uow, new BrokenConcertRepository(), _reservationRepository);

            _reservationId = service.Reserve(_concert.Id, customer.Id, RequestedTickets);
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
