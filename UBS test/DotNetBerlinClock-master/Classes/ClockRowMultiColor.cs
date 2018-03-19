using System;
using BerlinClock.Classes.Enums;
using BerlinClock.Classes.Res;

namespace BerlinClock.Classes
{
    public class ClockRowMultiColor : ClockRow
    {
        private readonly Color secondaryColor;
        private readonly int secondaryColorAlteration;

        public ClockRowMultiColor(int numberOfLights, int maxCellValue, Color primaryColor, Color secondaryColor, int secondaryColorAlteration)
            : base(numberOfLights, maxCellValue, primaryColor)
        {
            this.secondaryColor = secondaryColor;
            if (secondaryColorAlteration <= 0)
            {
                throw new ArgumentException(ErrorMessages.Value_must_be_greater_then_0, nameof(maxCellValue));
            }
            this.secondaryColorAlteration = secondaryColorAlteration;
        }

        protected override void Hilight(int index)
        {
            var isAlteratingRow = (index + 1) % secondaryColorAlteration == 0;
            if (isAlteratingRow)
            {
                lights[index] = secondaryColor;
            }
            else
            {
                base.Hilight(index);
            }
        }
    }
}
