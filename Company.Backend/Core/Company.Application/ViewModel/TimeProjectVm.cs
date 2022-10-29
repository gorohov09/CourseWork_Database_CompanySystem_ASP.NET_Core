namespace Company.Application.ViewModel
{
    public class TimeProjectVm
    {
        public int Days { get; }

        public int Hours { get; }

        public int Minutes { get; }

        public TimeProjectVm(int Days, int Hours, int Minutes)
        {
            if (Hours > 24 || Minutes > 60)
                throw new ArgumentOutOfRangeException(nameof(Hours), nameof(Minutes));

            this.Days = Days;
            this.Hours = Hours;
            this.Minutes = Minutes;
        }
    }
}
