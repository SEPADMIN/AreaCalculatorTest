using System;

namespace CalcLib {
    public class Circle : IPolygonWithArea {
        public double Radius { get; set; }

        public Circle(double radius) {
            if(radius <= 0)
                throw new ArgumentException($"Radius of {typeof(Circle).Name} cannot be less or equal to 0");
            
            Radius = radius;
        }

        #region IPolygonWithArea
        public double FindArea() {
            return Math.PI * Math.Pow(Radius, 2) / 2;
        }
        #endregion

        public override string ToString() {
            return "Object of type: " + typeof(Circle).Name + ", radius = " + Radius.ToString("0.00");
        }
    }
}
