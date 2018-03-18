using System;
using BerlinClock.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClockUnitTests
{
    [TestClass]
    public class ClockTests
    {
        [TestMethod]
        public void TestsIfSetTimeCanParseValidTime()
        {
            var clock = new Clock();
            clock.SetTime(DateTime.Now.ToString());
            var result = clock.ToString();
            Assert.IsNotNull(result);
            Assert.IsFalse(result == string.Empty);
        }

        [TestMethod]
        public void TestsIfSetTimeCanParseMidninght24()
        {
            var clock = new Clock();
            clock.SetTime("24:00:00");
            var result = clock.ToString();
            Assert.IsNotNull(result);
            Assert.IsFalse(result == string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "2400:00 Is not a valid date format")]
        public void TestsIfSetTimeThrowsException()
        {
            var clock = new Clock();
            clock.SetTime("2400:00");
        }
    }
}
