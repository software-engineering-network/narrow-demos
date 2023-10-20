using Uow.Domain;

namespace Uow.Spec;

public class BrokenReservationRepository : IReservationRepository
{
    public void Create(Reservation reservation)
    {
        throw new NotImplementedException();
    }

    public void Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public void DeleteAll()
    {
        throw new NotImplementedException();
    }

    public bool Exists(Guid id) => throw new NotImplementedException();
}
