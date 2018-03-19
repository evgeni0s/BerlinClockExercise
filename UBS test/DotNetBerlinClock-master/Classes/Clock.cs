using System;
using System.Collections.Generic;
using System.Linq;
using BerlinClock.Classes.Interfaces;
using BerlinClock.Classes.Res;

namespace BerlinClock.Classes
{
    public class Clock : IClock
    {
        private readonly string midnight24 = "24:00:00";
        private readonly List<IClockRow> rows;
        private readonly IClockRowFactory rowfactory = new ClockRowFactory();

        public Clock()
        {
            rows = Enumerable.Range(0, 5).Select(index => rowfactory.GetRow(index)).ToList();
        }

        public void SetTime(string aTime)
        {
            DateTime dateTime;
            int hours;
            int minutes;
            int seconds;
            if (aTime == midnight24)
            {
                // Special case because in C# there is no such date
                hours = 24;
                minutes = 0;
                seconds = 0;
            }
            else if (DateTime.TryParse(aTime, out dateTime))
            {
                hours = dateTime.Hour;
                minutes = dateTime.Minute;
                seconds = dateTime.Second;
            }
            else
            {
                throw new Exception(aTime + ErrorMessages.Error_Converting_Color_To_String_Unexpected_Color);
            }
            seconds = seconds % 2 == 0 ? 1 : 0;
            rows[0].Fill(seconds);
            var hoursRemainder = rows[1].Fill(hours);
            rows[2].Fill(hoursRemainder);
            var minutesRemainder = rows[3].Fill(minutes);
            rows[4].Fill(minutesRemainder);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, rows);
        }
    }
}
