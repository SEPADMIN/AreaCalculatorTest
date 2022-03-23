using System;

namespace CalcLib {
    public class Square : RegularPolygon {
        public Square(double sideLength) : base(4, sideLength) {}

        public override double FindArea() {
            return GetSideLength() * GetSideLength();
        }
    }
}
