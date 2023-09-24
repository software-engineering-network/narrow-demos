namespace ConsoleApps.Domain;

public interface IDealershipRepository : IRepository<Dealership>
{
    void Create(Dealership dealership);
    Dealership Find(Guid id);
}
