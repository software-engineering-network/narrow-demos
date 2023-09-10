namespace Mocking.Problems;

public static class ShiftExtensions
{
    public static Shift Next(this Shift shift) =>
        shift switch
        {
            Shift.First => Shift.Second,
            Shift.Second => Shift.Third,
            Shift.Third => Shift.First
        };
}
