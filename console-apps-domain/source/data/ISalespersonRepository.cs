namespace ConsoleApps.Domain;

public interface ISalespersonRepository : IRepository<Salesperson>
{
    void Create(Salesperson salesperson);
    Salesperson Find(Guid id);
}
