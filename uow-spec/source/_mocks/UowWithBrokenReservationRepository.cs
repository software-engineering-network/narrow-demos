using System.Diagnostics;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using Uow.Domain;
using Uow.Infrastructure.Clients;
using Uow.Infrastructure.Clients.Pattern;
using Uow.Infrastructure.Venues.Naive;

namespace Uow.Spec;

public class UowWithBrokenReservationRepository : IUow
{
    private readonly Context _clientsContext;
    private readonly TransactionScope _scope;
    private readonly Infrastructure.Venues.Context _venuesContext;
    private IConcertRepository? _concerts;
    private ICustomerRepository? _customers;
    private IReservationRepository? _reservations;

    public UowWithBrokenReservationRepository()
    {
        _scope = new TransactionScope();
        _clientsContext = new();
        _venuesContext = new();
    }

    public IConcertRepository Concerts => _concerts ??= new ConcertRepository(_venuesContext);
    public ICustomerRepository Customers => _customers ??= new CustomerRepository(_clientsContext);
    public IReservationRepository Reservations => _reservations ??= new ReservationRepository(_clientsContext);

    public void Commit()
    {
        try
        {
            _clientsContext.Database.CloseConnection();
            _clientsContext.SaveChanges();

            _venuesContext.SaveChanges();

            _scope.Complete();
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
        }
    }
}
