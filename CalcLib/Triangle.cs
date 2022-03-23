using System;
using System.Collections.Generic;

namespace CalcLib {
    public class Triangle : IPolygonWithArea {
        private List<double> Sides;
        private double relativeComparisonPrecision;
        private double comparisonTolerance;

        internal static double DEFAULT_PRECISION = 0.0001;
        
        public double RelativeComparisonPrecision {
            get {
                return relativeComparisonPrecision;
            }
            set {
                if(value > 0) {
                    relativeComparisonPrecision = value;
                    comparisonTolerance = Math.Abs(Sides[0] * RelativeComparisonPrecision);
                }
                else {
                    throw new ArgumentException($"{nameof(RelativeComparisonPrecision)} should be a positive double");
                }
            } 
        }

        public Triangle(double sideA, double sideB, double sideC) {
            if(sideA <= 0 || sideB <= 0 || sideC <= 0)
                throw new ArgumentException($"Sides of {typeof(Triangle).Name} cannot be less or equal to 0");
            
            Sides = new List<double>() { sideA, sideB, sideC };
            Sides.Sort();
            RelativeComparisonPrecision = DEFAULT_PRECISION;
        }

        #region IPolygonWithArea
        public double FindArea() {
            double ph = (Sides[0] + Sides[1] + Sides[2]) / 2; // half of perimeter
            return Math.Sqrt(ph * (ph - Sides[0]) * (ph - Sides[1]) * (ph - Sides[2]));
        }
        #endregion

        public bool IsOrthogonal() {
            double firstLegSquared = Sides[0] * Sides[0];
            double secondLegSquared = Sides[1] * Sides[1];
            double hypotenuseSquared = Sides[2] * Sides[2];

            if (Math.Abs(hypotenuseSquared - (firstLegSquared + secondLegSquared)) > comparisonTolerance)
                return false;
            return true;
        }

        public bool IsRegularPolygon() {
            if((Sides[2] - Sides[1]) > comparisonTolerance // Math.Abs() is not required because Sides[] is sorted
                || (Sides[1] - Sides[0]) > comparisonTolerance)
                return false;
            return true;
        }

        public static implicit operator RegularPolygon(Triangle t) {
            if(t.IsRegularPolygon())
                return new RegularPolygon(3, t.Sides[0]);
            else
                throw new InvalidCastException($"Cannot cast {typeof(Triangle).Name} to {typeof(RegularPolygon).Name} - sides of {typeof(Triangle).Name} are not equal");
        }

        public static explicit operator Triangle(RegularPolygon rp) {

            if(rp.GetSidesCount() == 3) {
                double sideLength = rp.GetSideLength();
                return new Triangle(sideLength, sideLength, sideLength);
            }
            else
                throw new InvalidCastException($"Cannot cast {typeof(RegularPolygon).Name} to {typeof(Triangle).Name} - sides count of {typeof(RegularPolygon).Name} is not 3");
        }

#if DEBUG
        internal List<double> GetSidesForTests() {
            return Sides;
        }

        internal double GetComparisonToleranceForTests() {
            return comparisonTolerance;
        }
#endif

        public override string ToString() {
            return "Object of type: " + typeof(Triangle).Name + ", sides: "
                + Sides[0].ToString("0.00") + ", " + Sides[1].ToString("0.00") + ", " + Sides[2].ToString("0.00");
        }
    }
}
