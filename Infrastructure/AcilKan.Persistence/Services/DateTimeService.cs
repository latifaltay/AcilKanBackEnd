using AcilKan.Application.Interfaces;

namespace AcilKan.Persistence.Services
{
  

    public class DateTimeService : IDateTimeService
    {
        private readonly TimeZoneInfo _turkeyTimeZone;

        public DateTimeService()
        {
            _turkeyTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time");
        }

        public DateTime GetCurrentTimeInTurkey()
        {
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, _turkeyTimeZone);
        }

        public DateTime ConvertToTurkeyTime(DateTime utcDateTime)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, _turkeyTimeZone);
        }
    }

}
