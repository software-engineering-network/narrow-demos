namespace Uow.Infrastructure.Venues;

public class Concert : Entity
{
    public Concert()
    {
    }

    public Concert(Domain.Concert source) : base(source.Id)
    {
        AvailableTickets = source.AvailableTickets;
    }

    public int AvailableTickets { get; set; }

    public static implicit operator Concert(Domain.Concert source) => new(source);
    public static implicit operator Domain.Concert(Concert source) => new(source.Id, source.AvailableTickets);
}
