namespace ConsoleApps.Domain;

public interface ISaleRepository : IRepository<Sale>
{
    void Create(Sale sale);
    Sale Find(Guid id);
}
