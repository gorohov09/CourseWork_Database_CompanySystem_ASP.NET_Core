using Company.Application.Interfaces;
using Company.Application.ViewModel;

namespace Company.Application.Services
{
    public class TimeService : ITimeService
    {
        public TimeProjectVm ConvertMinutesInTime(long minutes)
        {
            var _days = minutes / 1440;
            minutes = minutes % 1440;

            var _hours = minutes / 60;

            var _minutes = minutes % 60;

            return new TimeProjectVm { Days = (int)_days, Hours = (int)_hours, Minutes = (int)_minutes };
        }

        public long ConvertTimeInMinutes(TimeProjectVm time)
        {
            return time.Days * 24 * 60 + time.Hours * 60 + time.Minutes;
        }
    }
}
