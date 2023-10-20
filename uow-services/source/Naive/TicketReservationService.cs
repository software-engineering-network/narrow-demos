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
        Reservation reservation;

        try
        {
            reservation = new Reservation(concertId, customerId, tickets);
            _reservationRepository.Create(reservation);
        }
        catch (Exception e)
        {
            return Guid.Empty;
        }

        try
        {
            var concert = _concertRepository.Find(concertId);
            concert.ReserveTickets(4);
            _concertRepository.Update(concert);
        }
        catch (Exception e)
        {
            _reservationRepository.Delete(reservation.Id);
            return Guid.Empty;
        }

        return reservation.Id;
    }
}
