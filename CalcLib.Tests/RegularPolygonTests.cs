using System;
using NUnit.Framework;

namespace CalcLib.Tests {
    public class RegularPolygonTests {
        private double errorTolerance;

        [SetUp]
        public void SetUp() {
            errorTolerance = 0.0001;
        }

        [Test]
        public void RegularPolygonCtorTests() {
            Assert.Throws<ArgumentException>(() => { RegularPolygon rp = new(0, 0); });
            Assert.Throws<ArgumentException>(() => { RegularPolygon rp = new(-1, -1); });
            Assert.Throws<ArgumentException>(() => { RegularPolygon rp = new(2, 1); });
            Assert.Throws<ArgumentException>(() => { RegularPolygon rp = new(1, 1); });
            Assert.Throws<ArgumentException>(() => { RegularPolygon rp = new(3, 0); });
            Assert.Throws<ArgumentException>(() => { RegularPolygon rp = new(-1, 1); });
            Assert.Throws<ArgumentException>(() => { RegularPolygon rp = new(3, -1); });
            Assert.DoesNotThrow(() => { RegularPolygon rp = new(3, 1); });
            Assert.DoesNotThrow(() => { RegularPolygon rp = new(3, 0.00001); });
            Assert.DoesNotThrow(() => { RegularPolygon rp = new(9, 5); });
        }

        [Test]
        public void GetSidesCountTests() {
            RegularPolygon rp = new(9, 5);
            int result = rp.GetSidesCount();
            int expectedResult = 9;
            Assert.AreEqual(expectedResult, result);

            RegularPolygon rp2 = new(4, 5);
            int result2 = rp2.GetSidesCount();
            int expectedResult2 = 4;
            Assert.AreEqual(expectedResult2, result2);
        }

        [Test]
        public void GetSideLengthTests() {
            RegularPolygon rp = new(9, 5.14);
            double result = rp.GetSideLength();
            double expectedResult = 5.14;
            Assert.AreEqual(expectedResult, result);

            RegularPolygon rp2 = new(4, Math.PI);
            double result2 = rp2.GetSideLength();
            double expectedResult2 = Math.PI;
            Assert.AreEqual(expectedResult2, result2);
        }

        [Test]
        public void FindAreaTests() {
            RegularPolygon rp = new(5, 10);
            double result = rp.FindArea();
            double expectedResult = 172.04774;
            double resultResidual = Math.Abs(expectedResult - result);
            Assert.IsTrue(resultResidual < errorTolerance);

            RegularPolygon rp2 = new(7, Math.PI);
            double result2 = rp2.FindArea();
            double expectedResult2 = 35.86527;
            double resultResidual2 = Math.Abs(expectedResult2 - result2);
            Assert.IsTrue(resultResidual2 < errorTolerance);

            RegularPolygon rp3 = new(4, 4);
            double result3 = rp3.FindArea();
            double expectedResult3 = 16;
            double resultResidual3 = Math.Abs(expectedResult3 - result3);
            Assert.IsTrue(resultResidual3 < errorTolerance);
        }
    }
}
