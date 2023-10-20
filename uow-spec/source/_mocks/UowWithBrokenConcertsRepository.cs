using System.Diagnostics;
using System.Transactions;
using Uow.Domain;
using Uow.Infrastructure.Clients;
using Uow.Infrastructure.Clients.Pattern;

namespace Uow.Spec;

public class UowWithBrokenConcertsRepository : IUow
{
    private readonly Context _clientsContext;
    private readonly Infrastructure.Venues.Context _venuesContext;
    private IConcertRepository? _concerts;
    private ICustomerRepository? _customers;
    private IReservationRepository? _reservations;

    public UowWithBrokenConcertsRepository(Context clientsContext, Infrastructure.Venues.Context venuesContext)
    {
        _clientsContext = clientsContext;
        _venuesContext = venuesContext;
    }

    public IConcertRepository Concerts => _concerts ??= new BrokenConcertRepository();
    public ICustomerRepository Customers => _customers ??= new CustomerRepository(_clientsContext);
    public IReservationRepository Reservations => _reservations ??= new BrokenReservationRepository();

    public void Commit()
    {
        try
        {
            using var scope = new TransactionScope();

            _clientsContext.SaveChanges();
            _venuesContext.SaveChanges();

            scope.Complete();
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
        }
    }
}
