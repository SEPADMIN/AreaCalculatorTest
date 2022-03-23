namespace CalcLib {
    public interface IRegularPolygon : IPolygonWithArea {
        public void SetSidesCount(int count);
        public void SetSideLength(double length);

        public int GetSidesCount();
        public double GetSideLength();
    }
}
