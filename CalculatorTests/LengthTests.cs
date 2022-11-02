using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tests
{
    [TestClass()]
    public class LengthTests
    {
        [TestMethod()]
        public void VerboseTest()
        {
            var length = new Length(10, MeasureType.ml);
            Assert.AreEqual("10 Мл.", length.Verbose());

            length = new Length(10, MeasureType.l);
            Assert.AreEqual("10 Л.", length.Verbose());

            length = new Length(10, MeasureType.m3);
            Assert.AreEqual("10 м3.", length.Verbose());

            length = new Length(10, MeasureType.bar);
            Assert.AreEqual("10 Баррел.", length.Verbose());
        }
        
        [TestMethod()]
        public void AddNumberTest()
        {
            var length= new Length(1, MeasureType.ml);
            length = length + 4.25;
            Assert.AreEqual("5.25 Мл.", length.Verbose());
        }

        [TestMethod()]
        public void SubNumberTest()
        {
            var length = new Length(3, MeasureType.ml);
            length = length - 1.75;
            Assert.AreEqual("1.25 Мл.", length.Verbose());
        }

        [TestMethod()]
        public void MulByNumberTest()
        {
            var length = new Length(3, MeasureType.ml);
            length = length * 3;
            Assert.AreEqual("9 Мл.", length.Verbose());
        }

        [TestMethod()]
        public void DivByNumberTest()
        {
            var length = new Length(3, MeasureType.ml);
            length = length / 3;
            Assert.AreEqual("1 Мл.", length.Verbose());
        }
        
        [TestMethod()]
        public void MeterToAnyTest()
        {
            Length length;

            length = new Length(1000, MeasureType.ml);
            Assert.AreEqual("1 Л.", length.To(MeasureType.l).Verbose());

            length = new Length(1000000, MeasureType.ml);
            Assert.AreEqual("1 м3.", length.To(MeasureType.m3).Verbose());

            length = new Length(158987.294928, MeasureType.ml);
            Assert.AreEqual("1 Баррел.", length.To(MeasureType.bar).Verbose());
        }

        [TestMethod()]
        public void AddSubKmMetersTest()
        {
            var ml = new Length(100, MeasureType.ml);
            var l = new Length(1, MeasureType.l);

            Assert.AreEqual("1100 Мл.", (ml + l).Verbose());
            Assert.AreEqual("1.1 Л.", (l + ml).Verbose());

            Assert.AreEqual("0.9 Л.", (l - ml).Verbose());
            Assert.AreEqual("-900 Мл.", (ml - l).Verbose());
        }
    }
}