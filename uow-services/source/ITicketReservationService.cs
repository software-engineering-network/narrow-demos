namespace Uow.Services;

public interface ITicketReservationService
{
    Guid Reserve(Guid concertId, Guid customerId, int tickets);
}
