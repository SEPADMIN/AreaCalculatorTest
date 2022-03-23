using System;
using NUnit.Framework;

namespace CalcLib.Tests {
    public class SquareTests {
        private double errorTolerance;

        [SetUp]
        public void SetUp() {
            errorTolerance = 0.0001;
        }

        [Test]
        public void SquareCtorTests() {
            Assert.Throws<ArgumentException>(() => { Square c = new(0); });
            Assert.Throws<ArgumentException>(() => { Square c = new(-1); });
            Assert.DoesNotThrow(() => { Square c = new(0.00000001); });
            Assert.DoesNotThrow(() => { Square c = new(3); });
        }

        [Test]
        public void FindAreaTests() {
            Square s = new(4);
            double result = s.FindArea();
            double expectedResult = 16;
            double resultResidual = Math.Abs(expectedResult - result);
            Assert.IsTrue(resultResidual < errorTolerance);

            Square s2 = new(Math.PI);
            double result2 = s2.FindArea();
            double expectedResult2 = Math.PI * Math.PI;
            double resultResidual2 = Math.Abs(expectedResult2 - result2);
            Assert.IsTrue(resultResidual2 < errorTolerance);

            Square s3 = new(547.455);
            double result3 = s3.FindArea();
            double expectedResult3 = 299706.977025;
            double resultResidual3 = Math.Abs(expectedResult3 - result3);
            Assert.IsTrue(resultResidual3 < errorTolerance);
        }
    }
}
