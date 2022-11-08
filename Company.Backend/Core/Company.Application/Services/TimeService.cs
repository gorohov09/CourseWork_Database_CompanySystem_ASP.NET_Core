using Company.Application.Interfaces;
using Company.Application.ViewModel;
using System.Text;

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

        public long ConvertTimeInMinutes(string time)
        {
            var timeProject = ConvertTimeString(time);
            return timeProject.Days * 24 * 60 + timeProject.Hours * 60 + timeProject.Minutes;
        }

        public bool CheckFormatTimeString(string time)
        {
            //good string: 12d 12h 12m
            //bad string: 12dd 12m
            var countSymbols = time.Count(ch => ch == 'd' || ch == 'h' || ch == 'm');
            if (countSymbols > 3)
                return false;

            if (countSymbols == 3)
                if (time.IndexOf('d') > time.IndexOf('h') || time.IndexOf('h') > time.IndexOf('m'))
                    return false;

            if (countSymbols == 2)
                if (time.IndexOf('d') > time.IndexOf('h') || time.IndexOf('h') > time.IndexOf('m')
                    || time.IndexOf('d') > time.IndexOf('m'))
                    return false;

            return true;
        }

        private TimeProjectVm ConvertTimeString(string time)
        {
            var result = new TimeProjectVm();

            for (int i = 0; i < time.Length; i++)
            {
                var firstIndex = -1;
                var secondIndex = -1;

                if (char.IsDigit(time[i]))
                {
                    firstIndex = i;
                }

                while (char.IsDigit(time[i]))
                {
                    i++;
                }
                secondIndex = i - 1;
                
                if (firstIndex != -1 && secondIndex != -1)
                {
                    var number = Convert.ToInt32(time.Substring(firstIndex, secondIndex - firstIndex + 1));

                    if (time[secondIndex + 1] == 'm')
                        result.Minutes = number;
                    else if (time[secondIndex + 1] == 'h')
                        result.Hours = number;
                    else if (time[secondIndex + 1] == 'd')
                        result.Days = number;
                }
            }

            return result;
        }
    }
}
