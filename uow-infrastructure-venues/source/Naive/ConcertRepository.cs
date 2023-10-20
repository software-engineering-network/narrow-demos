﻿using Uow.Domain;

namespace Uow.Infrastructure.Venues.Naive;

public class ConcertRepository : IConcertRepository
{
    private readonly Context _context;

    public ConcertRepository(Context context)
    {
        _context = context;
    }

    public void Create(Domain.Concert concert)
    {
        _context.Concert.Add(concert);
        _context.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var concert = _context.Concert.Find(id);
        _context.Concert.Remove(concert);
        _context.SaveChanges();
    }

    public Domain.Concert Find(Guid id) => _context.Concert.Single(x => x.Id == id);

    public void Update(Domain.Concert concert)
    {
        var dbConcert = _context.Concert.Single(x => x.Id == concert.Id);
        dbConcert.AvailableTickets = concert.AvailableTickets;
        _context.SaveChanges();
    }
}
