using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes
{
    public class Clock
    {
        private readonly string Midnight24 = "24:00:00";
        private List<ClockRow> rows;
        public Clock()
        {
            rows = new List<ClockRow>
            {
                new ClockRow(1, 1, Color.Yellow),
                new ClockRow(4, 5, Color.Red),
                new ClockRow(4, 1, Color.Red),
                new ClockRowMultiColor(11, 5, Color.Yellow, Color.Red, 3),
                new ClockRow(4, 1, Color.Yellow)
            };
        }

        public void SetTime(string aTime)
        {
            DateTime dateTime;
            if (aTime == Midnight24)
            {
                // Special case because in C# there is no such format
                SetMidnight();
            }
            else if (DateTime.TryParse(aTime, out dateTime))
            {
                var seconds = dateTime.Second % 2 == 0 ? 1 : 0;
                rows[0].Fill(seconds);
                var hoursRemainder = rows[1].Fill(dateTime.Hour);
                rows[2].Fill(hoursRemainder);
                var minutesRemainder = rows[3].Fill(dateTime.Minute);
                rows[4].Fill(minutesRemainder);
            }
            else
            {
                throw new Exception($"{aTime} Is not a valid date format");
            }
        }
        
        public void SetMidnight()
        {
            rows[0].Fill(1);
            rows[1].Fill(24);
            rows[2].Fill(24);
            rows[3].Fill(0);
            rows[4].Fill(0);
        }
      
        public override string ToString()
        {
            return string.Join(Environment.NewLine, rows);
        }
    }
}
