using System.Transactions;
using Uow.Domain;

namespace Uow.Services.Pattern;

public class TicketReservationService : ITicketReservationService
{
    private readonly IConcertRepository _concertRepository;
    private readonly IReservationRepository _reservationRepository;
    private readonly IUnitOfWork _uow;

    public TicketReservationService(
        IUnitOfWork uow,
        IConcertRepository concertRepository,
        IReservationRepository reservationRepository
    )
    {
        _uow = uow;
        _concertRepository = concertRepository;
        _reservationRepository = reservationRepository;
    }

    public Guid Reserve(Guid concertId, Guid customerId, int tickets)
    {
        TransactionManager.ImplicitDistributedTransactions = true;

        using var scope = new TransactionScope();

        var reservation = new Reservation(concertId, customerId, tickets);
        _reservationRepository.Create(reservation);

        var concert = _concertRepository.Find(concertId);
        concert.ReserveTickets(4);
        _concertRepository.Update(concert);

        _uow.Commit();

        scope.Complete();

        return reservation.Id;
    }
}

public interface IUnitOfWork
{
    void Commit();
}
