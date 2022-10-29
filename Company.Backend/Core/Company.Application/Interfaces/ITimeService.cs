using Company.Application.ViewModel;

namespace Company.Application.Interfaces
{
    public interface ITimeService
    {
        long ConvertTimeInMinutes(TimeProjectVm time);

        TimeProjectVm ConvertMinutesInTime(int minutes);
    }
}
