using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        
        public string convertTime(string aTime)
        {
            var berlinClock = new Classes.Clock();
            berlinClock.SetTime(aTime);
            return berlinClock.ToString();
        }
    }
}
