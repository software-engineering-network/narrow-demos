using Uow.Domain;

namespace Uow.Services.Naive;

public class TicketReservationService : ITicketReservationService
{
    private readonly IConcertRepository _concertRepository;
    private readonly IReservationRepository _reservationRepository;

    public TicketReservationService(
        IConcertRepository concertRepository,
        IReservationRepository reservationRepository
    )
    {
        _concertRepository = concertRepository;
        _reservationRepository = reservationRepository;
    }

    public Guid Reserve(Guid concertId, Guid customerId, int tickets)
    {
        var reservation = new Reservation(concertId, customerId, tickets);
        _reservationRepository.Create(reservation);

        var concert = _concertRepository.Find(concertId);
        concert.ReserveTickets(4);
        _concertRepository.Update(concert);

        return reservation.Id;
    }
}
