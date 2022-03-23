using System;
using NUnit.Framework;

namespace CalcLib.Tests {
    public class CircleTests {
        private double errorTolerance;

        [SetUp]
        public void SetUp() {
            errorTolerance = 0.0001;
        }

        [Test]
        public void CircleCtorTests() {
            Assert.Throws<ArgumentException>(() => { Circle c = new(0); });
            Assert.Throws<ArgumentException>(() => { Circle c = new(-1); });
            Assert.DoesNotThrow(() => { Circle c = new(0.00000001); });
            Assert.DoesNotThrow(() => { Circle c = new(3); });
        }

        [Test]
        public void FindAreaTests() {
            Circle c = new(Math.Sqrt(1 / Math.PI));
            double result = c.FindArea();
            double expectedResult = 0.5;
            double resultResidual = Math.Abs(expectedResult - result);
            Assert.IsTrue(resultResidual < errorTolerance);

            Circle c2 = new(Math.PI);
            double result2 = c2.FindArea();
            double expectedResult2 = Math.Pow(Math.PI, 3) / 2;
            double resultResidual2 = Math.Abs(expectedResult2 - result2);
            Assert.IsTrue(resultResidual2 < errorTolerance);
        }
    }
}
