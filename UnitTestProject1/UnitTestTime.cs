using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeLib;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestTime
    {
        [DataTestMethod]
        [DataRow(1)]
        [DataRow(10)]
        [DataRow(25)]
        [DataRow(48)]
        public void Constructor_OneArgument(int hours)
        {
            Time t = new Time(hours);
            Assert.AreEqual(t.Hours, hours % 12);
        }
        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(10, 10)]
        [DataRow(25, 60)]
        [DataRow(48, 232)]
        public void Constructor_TwoArgument(int hours, int minutes)
        {
            Time t = new Time(hours, minutes);
            Assert.AreEqual(t.Hours, hours % 12);
            Assert.AreEqual(t.Minutes, minutes % 60);


        }
        [DataTestMethod]
        [DataRow(1, 1, 21)]
        [DataRow(10, 10, 32)]
        [DataRow(25, 60, 60)]
        [DataRow(48, 232, 123)]
        public void Constructor_ThreeArgument(int hours, int minutes, int seconds)
        {
            Time t = new Time(hours, minutes, seconds);
            Assert.AreEqual(t.Hours, hours % 12);
            Assert.AreEqual(t.Minutes, minutes % 60);
            Assert.AreEqual(t.Second, seconds % 60);

        }
        [TestMethod]
        public void Constructor_OneStringAgrument()
        {
            Time t = new Time("12:32:23");
            Assert.AreEqual(t.Second, 23);
            Assert.AreEqual(t.Minutes, 32);
            Assert.AreEqual(t.Hours, 12);


        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_OneStringAgrument_Exception1()
        {
            Time t = new Time("13,32,12");
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Constructor_OneStringAgrument_Exception2()
        {
            string s = null;
            Time t = new Time(s);
        }

        [TestMethod]
        public void TimeToString()
        {
            Time t = new Time(12, 12, 12);
            Assert.AreEqual("12:12:12", t.ToString());
        }

        [TestMethod]
        public void EqualsTime()
        {
            Time t = new Time(12, 12, 12);
            Time t1 = new Time(12, 12, 12);
            Assert.IsTrue(t.Equals(t1));

        }

        [TestMethod]
        public void CompareToTest()
        {
            Time t = new Time(12, 12, 12);
            Time t2 = new Time(12, 12, 12);
            Time t3 = new Time(12, 12, 13);
            Time t4 = new Time(12, 12, 11);

            Assert.AreEqual(t.CompareTo(t2), 0);
            Assert.AreEqual(t.CompareTo(t3), -1);
            Assert.AreEqual(t.CompareTo(t4), 1);
        }



        [TestMethod]
        public void TestOperator()
        {
            Time t = new Time(12, 12, 12);
            Time t2 = new Time(12, 12, 13);
            Assert.IsTrue(t != t2);
            Assert.IsFalse(t == t2);
            Assert.IsFalse(t2 < t);
            Assert.IsFalse(t2 <= t);
            Assert.IsTrue(t2 > t);
            Assert.IsTrue(t2 >= t);

        }

        [TestMethod]
        public void TestOperator1()
        {
            TimePeriod tp = new TimePeriod(10, 10, 10);
            Time t = new Time(24, 10, 10);
            Assert.AreEqual((t + tp).ToString(), "10:20:20");


        }
    }
}
