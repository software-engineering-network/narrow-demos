namespace Mocking;

public interface IDateTimeProvider
{
    DateTime Now { get; }
}

public class MockDateTimeProvider : IDateTimeProvider
{
    public DateTime Now => new(2023, 01, 01);
}
