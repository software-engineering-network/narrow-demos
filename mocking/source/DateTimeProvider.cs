namespace Mocking;

public interface IDateTimeProvider
{
    DateTime Now { get; }
}

public class MockDateTimeProvider : IDateTimeProvider
{
    #region IDateTimeProvider Implementation

    public DateTime Now => new(2023, 01, 01);

    #endregion
}
