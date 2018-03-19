using System;
using BerlinClock.Classes;
using BerlinClock.Classes.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClockUnitTests
{
    [TestClass]
    public class ClockRowTests
    {
        [TestMethod]
        public void ClockRowCanInitializeWithcorrectParameters()
        {
            var clockRow = new ClockRow(2, 3, Color.Red);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "ClockRow: Value must be greater then 0")]
        public void ClockRowThrowsExceptionIfNumberOfLightsEqualToZero()
        {
            var clockRow = new ClockRow(0, 3, Color.Red);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "ClockRow: Value must be greater then 0")]
        public void ClockRowThrowsExceptionIfMaxCellValueEqualToZero()
        {
            var clockRow = new ClockRow(2, 0, Color.Red);
        }
        
        [TestMethod]
        public void ClockRowFillWithoutRemainerTest()
        {
            var clockRow = new ClockRow(2, 3, Color.Red);
            var remainder = clockRow.Fill(6);
            Assert.IsTrue(remainder == 0);
        }

        [TestMethod]
        public void ClockRowFillWithRemainerTest()
        {
            var clockRow = new ClockRow(2, 3, Color.Red);
            var remainder = clockRow.Fill(100);
            Assert.IsTrue(remainder == 94);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "ClockRow: Value must be positive")]
        public void ClockRowThrowsExceptionIfFillNegativeNumberTest()
        {
            var clockRow = new ClockRow(2, 3, Color.Red);
            var remainder = clockRow.Fill(-100);
        }
    }
}
