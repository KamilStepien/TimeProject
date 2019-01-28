using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeLib;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestTimePeriod
    {
        [DataTestMethod]
        [DataRow(1)]
        [DataRow(10)]
        [DataRow(25)]
        [DataRow(48)]
        public void Constructor_OneArgument(int second)
        {
            TimePeriod t = new TimePeriod(second);
            Assert.AreEqual(t.Second, second );
        }
        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(10, 10)]
        [DataRow(25, 60)]
        [DataRow(48, 232)]
        public void Constructor_TwoArgument(int hours, int minutes)
        {
            TimePeriod t = new TimePeriod(hours, minutes);
            Assert.AreEqual(t.Second, hours*3600+ minutes*60);

        }
        [DataTestMethod]
        [DataRow(1, 1, 21)]
        [DataRow(10, 10, 32)]
        [DataRow(25, 60, 60)]
        [DataRow(48, 232, 123)]
        public void Constructor_ThreeArgument(int hours, int minutes, int seconds)
        {
            TimePeriod t = new TimePeriod(hours, minutes ,seconds);
            Assert.AreEqual(t.Second, hours * 3600 + minutes * 60 +seconds);

        }
        
        [TestMethod]
        public void Constructor_OneStringAgrument()
        {
            TimePeriod t = new TimePeriod("12:32:23");
            Assert.AreEqual(t.Second, 12*3600+32*60+23);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_OneStringAgrument_Exception1()
        {
            TimePeriod t = new TimePeriod("13,32,12");
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Constructor_OneStringAgrument_Exception2()
        {
            string s = null;
            TimePeriod t = new TimePeriod(s);
        }


        [TestMethod]
        public void Constructor_TwoTimeAtgument()
        {
            Time t1 = new Time(12, 12, 12);
            Time t2 = new Time(13, 12, 12);
            TimePeriod t = new TimePeriod( t1,  t2);
            Assert.AreEqual(t.Second,  3600);
            t1 = new Time(13, 13, 13);
             t = new TimePeriod(t1, t2);
            Assert.AreEqual(t.Second, 0);
        }
        
        [TestMethod]
        public void TimeToString()
        {
            TimePeriod t = new TimePeriod(12, 12, 12);
            Assert.AreEqual("12:12:12", t.ToString());
        }

        [TestMethod]
        public void EqualsTime()
        {
            TimePeriod t = new TimePeriod(12, 12, 12);
            TimePeriod t1 = new TimePeriod(12, 12, 12);
            Assert.IsTrue(t.Equals(t1));

        }
        
        [TestMethod]
        public void CompareToTest()
        {
            TimePeriod t = new TimePeriod(12, 12, 12);
            TimePeriod t2 = new TimePeriod(12, 12, 12);
            TimePeriod t3 = new TimePeriod(12, 12, 13);
            TimePeriod t4 = new TimePeriod(12, 12, 11);

            Assert.AreEqual(t.CompareTo(t2), 0);
            Assert.AreEqual(t.CompareTo(t3), -1);
            Assert.AreEqual(t.CompareTo(t4), 1);
        }



        [TestMethod]
        public void TestOperator()
        {
            TimePeriod t = new TimePeriod(12, 12, 12);
            TimePeriod t2 = new TimePeriod(12, 12, 13);
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
            TimePeriod tp1 = new TimePeriod(40, 12, 12);
            TimePeriod tp2 = new TimePeriod(12, 12, 12);
            Assert.AreEqual((tp1 + tp2).ToString(), "52:24:24");
        }

    }
}
