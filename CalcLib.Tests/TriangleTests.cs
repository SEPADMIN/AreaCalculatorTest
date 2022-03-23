using System;
using CalcLib;
using NUnit.Framework;

namespace CalcLibTest {
    public class TriangleTests {
        [Test]
        public void RegularPolygonImplicitCastTests() {
            Triangle t = new(3, 3, 3);
            Assert.DoesNotThrow(() => { RegularPolygon rp = t; });

            RegularPolygon rp = t;
            Assert.AreEqual(3, rp.GetSideLength());
            Assert.AreEqual(t.GetSides()[0], rp.GetSideLength());

            Triangle t2 = new(3, 4, 5);
            Assert.Throws<InvalidCastException>(() => { RegularPolygon rp = t2; });
        }

        [Test]
        public void RegularPolygonExplicitCastTests() {
            RegularPolygon rp = new(3, 5);
            Assert.DoesNotThrow(() => { Triangle t = rp; });

            Triangle t = (Triangle)rp;
            foreach(double side in t.GetSides()) {
                Assert.AreEqual(5, side);
            }

            RegularPolygon rp2 = new(4, 1);
            Assert.Throws<InvalidCastException>(() => { Triangle t = rp2; });
        }

        [Test]
        public void TriangleCtorTests() {
            Assert.Throws<ArgumentException>(() => { Triangle t = new(0, 1, 2); });
            Assert.Throws<ArgumentException>(() => { Triangle t = new(3, 8, -2); });
            Assert.DoesNotThrow(() => { Triangle t = new(0.0001, 0.0001, 0.0001); });
        }

        [Test]
        public void FindAreaTests() {
            Triangle t = new(3, 3, 3);
            double result = t.FindArea();
            double expectedResult = 3.897114;
            double resultResidual = Math.Abs(expectedResult - result);
            Assert.IsTrue(resultResidual < t.GetComparisonTolerance());

            Triangle t2 = new(3, 4, 5);
            double result2 = t2.FindArea();
            double expectedResult2 = 6;
            double resultResidual2 = Math.Abs(expectedResult2 - result2);
            Assert.IsTrue(resultResidual2 < t2.GetComparisonTolerance());

            Triangle t3 = new(6, 8, 10);
            double result3 = t3.FindArea();
            double expectedResult3 = 24;
            double resultResidual3 = Math.Abs(expectedResult3 - result3);
            Assert.IsTrue(resultResidual3 < t3.GetComparisonTolerance());
        }

        [Test]
        public void IsOrthogonalTests() {
            Triangle t = new(3, 3, 3);
            Assert.IsFalse(t.IsOrthogonal());

            Triangle t2 = new(3, 4, 5);
            Assert.IsTrue(t2.IsOrthogonal());

            Triangle t3 = new(3, 4, 5.0001);
            t3.RelativeComparisonPrecision = Triangle.DEFAULT_PRECISION;
            Assert.IsFalse(t3.IsOrthogonal());
            t3.RelativeComparisonPrecision = 0.001;
            Assert.IsTrue(t3.IsOrthogonal());
        }

        [Test]
        public void IsRegularPolygonTests() {
            Triangle t = new(3, 4, 5);
            Assert.IsFalse(RegularPolygon.IsRegularPolygon(t.GetSides(), t.GetComparisonTolerance()));

            Triangle t2 = new(3, 3, 3);
            Assert.IsTrue(RegularPolygon.IsRegularPolygon(t2.GetSides(), t2.GetComparisonTolerance()));

            Triangle t3 = new(3, 3, 3.0007);
            t3.RelativeComparisonPrecision = Triangle.DEFAULT_PRECISION;
            Assert.IsFalse(RegularPolygon.IsRegularPolygon(t3.GetSides(), t3.GetComparisonTolerance()));
            t3.RelativeComparisonPrecision = 0.001;
            Assert.IsTrue(RegularPolygon.IsRegularPolygon(t3.GetSides(), t3.GetComparisonTolerance()));
        }
    }
}