using Company.Application.ViewModel;

namespace Company.Application.Interfaces
{
    public interface ITimeService
    {
        int ConvertTimeInMinutes(TimeProjectVm time);

        TimeProjectVm ConvertMinutesInTime(int minutes);
    }
}
