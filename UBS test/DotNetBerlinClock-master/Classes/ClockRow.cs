using System;
using System.Linq;
using BerlinClock.Classes.Enums;
using BerlinClock.Classes.Interfaces;
using BerlinClock.Classes.Res;

namespace BerlinClock.Classes
{
    public class ClockRow : IClockRow
    {
        protected readonly Color[] lights;
        protected readonly Color primaryColor;
        protected readonly int cellSize;

        public ClockRow(int numberOfLights, int cellSize, Color primaryColor)
        {
            if (numberOfLights <= 0)
            {
                throw new ArgumentException(ErrorMessages.Value_must_be_greater_then_0, nameof(numberOfLights));
            }
            if (cellSize <= 0)
            {
                throw new ArgumentException(ErrorMessages.Value_must_be_greater_then_0, nameof(cellSize));
            }
            lights = new Color[numberOfLights];
            this.primaryColor = primaryColor;
            this.cellSize = cellSize;
        }

        public virtual int Fill(int time)
        {
            if (time < 0)
            {
                throw new ArgumentException(ErrorMessages.Value_must_be_positive, nameof(time));
            }
            ResetLights();

            var numOfCellsRequestedToFill = time / cellSize;
            var cellsToHilight = numOfCellsRequestedToFill > lights.Length ? lights.Length : numOfCellsRequestedToFill;
            for (int i = 0; i < cellsToHilight; i++)
            {
                Hilight(i);
            }
            var remainder = time - cellsToHilight * cellSize;
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
            throw new ArgumentException(ErrorMessages.Error_Converting_Color_To_String_Unexpected_Color + color, nameof(color));
        }

        public override string ToString()
        {
            return string.Join(string.Empty, lights.Select(ColorToStringConvertor));
        }
    }
}
