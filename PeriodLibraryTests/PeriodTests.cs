using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeriodLibrary;
using System;

namespace PeriodLibraryTests
{
    [TestClass]
    public class PeriodTest
    {
        [TestMethod]
        public void ObjectEquals_SamePeriods_ReturnsTrue()
        {
            var start = new DateTime(2018, 1, 1);
            var end = new DateTime(2018, 12, 31);
            var p1 = new Period(start, end);
            object p2 = new Period(start, end);

            Assert.IsTrue(p1.Equals(p2));
        }

        [TestMethod]
        public void Equals_SamePeriods_ReturnsTrue()
        {
            var start = new DateTime(2018, 1, 1);
            var end = new DateTime(2018, 12, 31);
            Period p1 = new Period(start, end);
            Period p2 = new Period(start, end);

            Assert.IsTrue(p1.Equals(p2));
        }

        [TestMethod]
        public void Equals_TwoDifferentPeriods_ReturnsFalse()
        {
            var start = new DateTime(2018, 1, 1);
            var end = new DateTime(2018, 12, 31);
            var p1 = new Period(start, end);
            var p2 = new Period(start, new DateTime(2018, 12, 30));

            Assert.IsFalse(p1.Equals(p2));
        }

        [TestMethod]
        public void Equals_Null_ReturnsFalse()
        {
            var start = new DateTime(2018, 1, 1);
            var end = new DateTime(2018, 12, 31);
            var p1 = new Period(start, end);

            Assert.IsFalse(p1.Equals(null));
        }
    }
}
