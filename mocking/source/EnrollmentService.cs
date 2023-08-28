namespace Mocking;

/// <remarks>
///     This is a domain service, not an application service.
///     It does not have any dependencies outside of the domain.
/// </remarks>
public class EnrollmentService
{
    private readonly IDateTimeProvider _dateTimeProvider;

    #region Creation

    public EnrollmentService(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    #endregion

    #region Implementation

    public Enrollment Register(Student student, Class @class)
    {
        @class.Add(student);
        return CreateEnrollment(student, @class, _dateTimeProvider.Now);
    }

    #endregion

    #region Static Interface

    private static Enrollment CreateEnrollment(Student student, Class @class, DateTime enrolledOn) =>
        new(@class.Id, student.Id, enrolledOn);

    #endregion
}
