namespace AcilKan.Application.Interfaces
{
    public interface IDateTimeService
    {
        DateTime GetCurrentTimeInTurkey();
        DateTime ConvertToTurkeyTime(DateTime utcDateTime);
    }
}
