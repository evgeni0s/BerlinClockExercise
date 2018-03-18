using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                throw new ArgumentException("ClockRow: Value must be greater then 0", nameof(maxCellValue));
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
