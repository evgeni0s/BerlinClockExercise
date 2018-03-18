using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes
{
    public class ClockRow
    {
        protected readonly Color[] lights;
        protected readonly Color primaryColor;
        protected readonly int maxCellValue;

        public ClockRow(int numberOfLights, int maxCellValue, Color primaryColor)
        {
            if (numberOfLights <= 0)
            {
                throw new ArgumentException("ClockRow: Value must be greater then 0", nameof(numberOfLights));
            }
            if (maxCellValue <= 0)
            {
                throw new ArgumentException("ClockRow: Value must be greater then 0", nameof(maxCellValue));
            }
            lights = new Color[numberOfLights];
            this.primaryColor = primaryColor;
            this.maxCellValue = maxCellValue;
        }

        public virtual int Fill(int time)
        {
            if (time < 0)
            {
                throw new ArgumentException("ClockRow: Value must be positive", nameof(time));
            }
            ResetLights();

            var numOfCellsRequestedToFill = time / maxCellValue;
            var cellsToHilight = numOfCellsRequestedToFill > lights.Length ? lights.Length : numOfCellsRequestedToFill;
            for (int i = 0; i < cellsToHilight; i++)
            {
                Hilight(i);
            }
            var remainder = time - cellsToHilight * maxCellValue;
            return remainder;
        }
        

        protected virtual void Hilight(int index)
        {
            if(index > -1 && index < lights.Length)
            {
                lights[index] = primaryColor;
            }
        }

        private void ResetLights() => Array.Clear(lights, 0, lights.Length);

        private string ColorToStringConvertor(Color color) {
            switch (color)
            {
                case Color.Undefined:
                    return "O";
                case Color.Yellow:
                    return "Y";
                case Color.Red:
                    return "R";
            }
            throw new Exception($"Error converting color to string. Unexpected color {color}");
        }

        public override string ToString()
        {
            return string.Join(string.Empty, lights.Select(ColorToStringConvertor));
        }
    }
}
