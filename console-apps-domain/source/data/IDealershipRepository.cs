﻿namespace ConsoleApps.Domain;

public interface IDealershipRepository : IRepository<Dealership>
{
    void Create(Dealership dealership);
    Dealership Find(Guid id);
}

public class DealershipRepository : IDealershipRepository
{
    private readonly Storage _storage;

    public DealershipRepository(Storage storage)
    {
        _storage = storage;
    }

    public void Create(Dealership dealership)
    {
        _storage.Dealerships.Add(dealership);
    }

    public Dealership Find(Guid id) => _storage.Dealerships.Single(x => x.Id == id);
}
