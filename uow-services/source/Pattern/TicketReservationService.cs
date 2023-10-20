using Uow.Domain;

namespace Uow.Services.Pattern;

public class TicketReservationService : ITicketReservationService
{
    private readonly IUow _uow;

    public TicketReservationService(IUow uow)
    {
        _uow = uow;
    }

    public Guid Reserve(Guid concertId, Guid customerId, int tickets)
    {
        var reservation = new Reservation(concertId, customerId, tickets);
        _uow.Reservations.Create(reservation);

        var concert = _uow.Concerts.Find(concertId);
        concert.ReserveTickets(4);
        _uow.Concerts.Update(concert);

        _uow.Commit();

        return reservation.Id;
    }
}
