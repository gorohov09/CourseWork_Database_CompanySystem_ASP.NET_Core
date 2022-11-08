using Company.Application.ViewModel;

namespace Company.Application.Interfaces
{
    public interface ITimeService
    {
        long ConvertTimeInMinutes(string time);

        TimeProjectVm ConvertMinutesInTime(long minutes);

        bool CheckFormatTimeString(string time);
    }
}
