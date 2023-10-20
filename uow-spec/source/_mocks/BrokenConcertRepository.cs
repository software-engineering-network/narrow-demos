using Uow.Domain;

namespace Uow.Spec;

public class BrokenConcertRepository : IConcertRepository
{
    public void Create(Concert concert)
    {
        throw new NotImplementedException();
    }

    public void Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Concert Find(Guid id) => throw new NotImplementedException();

    public void Update(Concert concert)
    {
        throw new NotImplementedException();
    }
}
