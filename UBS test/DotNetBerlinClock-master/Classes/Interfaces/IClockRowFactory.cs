namespace BerlinClock.Classes.Interfaces
{
    public interface IClockRowFactory
    {
        IClockRow GetRow(int position);
    }
}