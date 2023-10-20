using Uow.Infrastructure.Clients;
using Uow.Services.Pattern;

namespace Uow.Spec.Pattern;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(Context clientsContext, Infrastructure.Venues.Context venuesContext)
    {
        ClientsContext = clientsContext;
        VenuesContext = venuesContext;
    }

    public Context ClientsContext { get; set; }
    public Infrastructure.Venues.Context VenuesContext { get; set; }

    public void Commit()
    {
        ClientsContext.SaveChanges();
        VenuesContext.SaveChanges();
    }
}
