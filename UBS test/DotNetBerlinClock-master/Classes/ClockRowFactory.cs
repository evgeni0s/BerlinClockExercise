using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BerlinClock.Classes.Enums;
using BerlinClock.Classes.Interfaces;

namespace BerlinClock.Classes
{
    public class ClockRowFactory : IClockRowFactory
    {
        public IClockRow GetRow(int position)
        {
            switch (position)
            {
                case 0:
                    return new ClockRow(1, 1, Color.Yellow);
                case 1:
                    return new ClockRow(4, 5, Color.Red);
                case 2:
                    return new ClockRow(4, 1, Color.Red);
                case 3:
                    return new ClockRowMultiColor(11, 5, Color.Yellow, Color.Red, 3);
                case 4:
                    return new ClockRow(4, 1, Color.Yellow);
            }
            return null;
        }
    }
}
