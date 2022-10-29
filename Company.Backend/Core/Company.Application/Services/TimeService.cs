using Company.Application.Interfaces;
using Company.Application.ViewModel;

namespace Company.Application.Services
{
    public class TimeService : ITimeService
    {
        public TimeProjectVm ConvertMinutesInTime(int minutes)
        {
            var _days = minutes / 1440;
            minutes = minutes % 1440;

            var _hours = minutes / 60;

            var _minutes = minutes % 60;

            return new TimeProjectVm(_days, _hours, _minutes);
        }

        public int ConvertTimeInMinutes(TimeProjectVm time)
        {
            return time.Days * 24 * 60 + time.Hours * 60 + time.Minutes;
        }
    }
}
