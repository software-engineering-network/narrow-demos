namespace Uow.Domain;

public class Concert : Entity
{
    public Concert(int availableTickets)
    {
        AvailableTickets = availableTickets;
    }

    public Concert(Guid id, int availableTickets) : base(id)
    {
        AvailableTickets = availableTickets;
    }

    public int AvailableTickets { get; private set; }

    public void ReserveTickets(int tickets)
    {
        AvailableTickets -= tickets;
    }
}

public interface IConcertRepository
{
    void Create(Concert concert);
    void Delete(Guid id);
    Concert Find(Guid id);
    void Update(Concert concert);
}
