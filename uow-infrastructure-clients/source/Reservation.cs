namespace Uow.Infrastructure.Clients;

public class Reservation : Entity
{
    public Reservation()
    {
    }

    public Reservation(Domain.Reservation source) : base(source.Id)
    {
        ConcertId = source.ConcertId;
        CustomerId = source.CustomerId;
        Tickets = source.Tickets;
    }

    public Guid ConcertId { get; set; }
    public Guid CustomerId { get; set; }
    public int Tickets { get; set; }

    public static implicit operator Reservation(Domain.Reservation source) => new(source);
}
