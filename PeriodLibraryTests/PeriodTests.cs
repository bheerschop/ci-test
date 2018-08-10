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

        [TestMethod]
        public void HasOverlap_Overlapping_ReturnsTrue(){
            var p1 = new Period(new DateTime(2018, 1, 1), new DateTime(2018, 2, 1));
            var p2 = new Period(new DateTime(2018, 1, 15), new DateTime(2018, 2, 15));

            Assert.IsTrue(p1.HasOverlap(p2));
        }

        [TestMethod]
        public void HasOverlap_NonOverlapping_ReturnsFalse(){
            var p1 = new Period(new DateTime(2018, 1, 1), new DateTime(2018, 2, 1));
            var p2 = new Period(new DateTime(2018, 2, 2), new DateTime(2018, 2, 15));

            Assert.IsFalse(p1.HasOverlap(p2), $"Expected {p1} to not overlap with {p2}.");
        }

        [TestMethod]
        public void HasOverlap_StartAndEndOnSameDay_ReturnsTrue(){
            var p1 = new Period(new DateTime(2018, 1, 1), new DateTime(2018, 2, 1));
            var p2 = new Period(new DateTime(2018, 2, 1), new DateTime(2018, 2, 15));

            Assert.IsTrue(p1.HasOverlap(p2));
        }

        [TestMethod]
        public void HasOverlap_StartOneSecondLater_ReturnsFalse(){
            var p1 = new Period(new DateTime(2018, 1, 1), new DateTime(2018, 2, 1));
            var p2 = new Period(new DateTime(2018, 2, 1, 0, 0, 1), new DateTime(2018, 2, 15));

            Assert.IsFalse(p1.HasOverlap(p2));
        }

        [TestMethod]
        public void HasOverlap_PeriodStartsBeforeAndEndsAfterOther_ReturnsTrue(){
            var p1 = new Period(new DateTime(2017, 1, 1), new DateTime(2019, 2, 1));
            var p2 = new Period(new DateTime(2018, 2, 1), new DateTime(2018, 2, 15));

            Assert.IsTrue(p1.HasOverlap(p2));
        }

        [TestMethod]
        public void HasOverlap_PeriodIsWithinOther_ReturnsTrue(){
            var p1 = new Period(new DateTime(2018, 1, 1), new DateTime(2019, 2, 1));
            var p2 = new Period(new DateTime(2017, 2, 1), new DateTime(2020, 1, 22));

            Assert.IsTrue(p1.HasOverlap(p2));
        }
    }
}
