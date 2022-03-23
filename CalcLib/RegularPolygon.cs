using System;

namespace CalcLib {
    public class RegularPolygon : IRegularPolygon {
        private int m_sidesCount;
        private double m_sideLength;

        public RegularPolygon(int sidesCount, double sideLength) {
            SetSidesCount(sidesCount);
            SetSideLength(sideLength);
        }

        #region IRegularPolygon
        public void SetSideLength(double length) {
            if(length <= 0)
                throw new ArgumentException($"Side length of {typeof(RegularPolygon).Name} cannot be less or equal to 0");
            else
                m_sideLength = length;
        }
        public void SetSidesCount(int count) {
            if(count <= 0)
                throw new ArgumentException($"Sides count of {typeof(RegularPolygon).Name} cannot be less or equal to 0");
            else
                m_sidesCount = count;
        }
        public int GetSidesCount() {
            return m_sidesCount;
        }
        public double GetSideLength() {
            return m_sideLength;
        }
        #endregion

        #region IPolygonWithArea
        public virtual double FindArea() {
            return (double)m_sidesCount / 4 * m_sideLength * m_sideLength / Math.Tan(Math.PI / m_sidesCount);
        }
        #endregion

        public override string ToString() {
            return "Object of type: " + typeof(RegularPolygon).Name + ", sides count = " 
                + m_sidesCount + ", side length = " + m_sideLength.ToString("0.00");
        }
    }
}
