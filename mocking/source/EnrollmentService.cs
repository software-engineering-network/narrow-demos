namespace Mocking;

/// <remarks>
///     This is a domain service, not an application service.
///     It does not have any dependencies outside of the domain.
/// </remarks>
public class EnrollmentService
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public EnrollmentService(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public Enrollment Register(Student student, Class @class)
    {
        @class.Add(student);
        return CreateEnrollment(student, @class, _dateTimeProvider.Now);
    }

    private static Enrollment CreateEnrollment(Student student, Class @class, DateTime enrolledOn) =>
        new(@class.Id, student.Id, enrolledOn);
}
