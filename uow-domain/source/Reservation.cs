namespace Uow.Domain;

public class Reservation : Entity
{
    public Reservation(Guid concertId, Guid customerId, int tickets)
    {
        ConcertId = concertId;
        CustomerId = customerId;
        Tickets = tickets;
    }

    public Reservation(Guid id, Guid concertId, Guid customerId, int tickets) : base(id)
    {
        ConcertId = concertId;
        CustomerId = customerId;
        Tickets = tickets;
    }

    public Guid ConcertId { get; }
    public Guid CustomerId { get; }
    public int Tickets { get; }
}

public interface IReservationRepository
{
    void Create(Reservation reservation);
    void DeleteAll();
    bool Exists(Guid id);
}
