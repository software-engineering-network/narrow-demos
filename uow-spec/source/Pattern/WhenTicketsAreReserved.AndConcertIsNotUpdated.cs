using FluentAssertions;
using Uow.Domain;
using Uow.Services;
using Uow.Services.Pattern;
using UnitOfWork = Uow.Infrastructure.Clients.Pattern.Uow;

namespace Uow.Spec.Pattern;

public partial class WhenTicketsAreReserved
{
    public class AndConcertIsNotUpdated : IClassFixture<Fixture>
    {
        #region Setup

        private const int RequestedTickets = 4;
        private readonly Concert _concert;
        private readonly Guid _reservationId;
        private readonly ITicketReservationService _service;
        private readonly IUow _uow;

        public AndConcertIsNotUpdated(Fixture fixture)
        {
            (_, _concert, var customer) = fixture;

            _service = new TicketReservationService(
                new UowWithBrokenConcertsRepository()
            );

            _reservationId = _service.Reserve(_concert.Id, customer.Id, RequestedTickets);
        }

        #endregion

        #region Requirements

        [Fact]
        public void ThenReservationIsRolledBack()
        {
            var uow = new UnitOfWork();
            uow.Reservations.Exists(_reservationId).Should().BeFalse();
        }

        #endregion
    }
}
