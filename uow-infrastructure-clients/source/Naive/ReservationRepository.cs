using Uow.Domain;

namespace Uow.Infrastructure.Clients.Naive;

public class ReservationRepository : IReservationRepository
{
    private readonly Context _context;

    public ReservationRepository(Context context)
    {
        _context = context;
    }

    public void Create(Domain.Reservation reservation)
    {
        _context.Reservation.Add(reservation);
        _context.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var reservation = _context.Reservation.Find(id);
        _context.Reservation.Remove(reservation);
        _context.SaveChanges();
    }

    public void DeleteAll()
    {
        foreach (var reservation in _context.Reservation)
            _context.Remove(reservation);

        _context.SaveChanges();
    }

    public bool Exists(Guid id) => _context.Reservation.Any(x => x.Id == id);
}
