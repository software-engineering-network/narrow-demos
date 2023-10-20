namespace Uow.Domain;

public interface IUow
{
    IConcertRepository Concerts { get; }
    ICustomerRepository Customers { get; }
    IReservationRepository Reservations { get; }
    void Commit();
}
