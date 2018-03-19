using System;
using BerlinClock.Classes;
using BerlinClock.Classes.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClockUnitTests
{
    [TestClass]
    public class ClockTests
    {
        private IClock stu;

        [TestInitialize]
        public void Initiallize()
        {
            stu = new Clock();
        }

        [TestMethod]
        public void TestsIfSetTimeCanParseValidTime()
        {
            stu.SetTime(DateTime.Now.ToString());
            var result = stu.ToString();
            Assert.IsNotNull(result);
            Assert.IsFalse(result == string.Empty);
        }

        [TestMethod]
        public void TestsIfSetTimeCanParseMidninght24()
        {
            stu.SetTime("24:00:00");
            var result = stu.ToString();
            Assert.IsNotNull(result);
            Assert.IsFalse(result == string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "2400:00 Is not a valid date format")]
        public void TestsIfSetTimeThrowsException()
        {
            stu.SetTime("2400:00");
        }
    }
}
