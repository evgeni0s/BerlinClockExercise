using BerlinClock.Classes.Interfaces;

namespace BerlinClock.Classes
{
    public class TimeConverter : ITimeConverter
    {
        private readonly IClock berlinClock;
        public TimeConverter()
        {
            berlinClock = new Clock();
        }

        public string ConvertTime(string aTime)
        {
            berlinClock.SetTime(aTime);
            return berlinClock.ToString();
        }
    }
}
