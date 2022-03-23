using System;
using CalcLib;

namespace AreaCalculator {
    class Program {
        static void Main(string[] args) {
            Circle circle = new(3);
            double circleArea = circle.FindArea();
            Console.WriteLine($"{nameof(circle)} info:\n" + circle);
            Console.WriteLine($"{nameof(circle)} area is: " + circleArea.ToString("0.00"));
            Console.WriteLine();

            Square square = new(4);
            double squareArea = square.FindArea();
            Console.WriteLine($"{nameof(square)} info:\n" + square);
            Console.WriteLine($"{nameof(square)} area is: " + squareArea.ToString("0.00"));
            Console.WriteLine();

            Triangle regularTriangle = new(3, 3, 3);
            double RegulartriangleArea = regularTriangle.FindArea();
            Console.WriteLine($"{nameof(regularTriangle)} info:\n" + regularTriangle);
            Console.WriteLine($"{nameof(regularTriangle)} area is: " + RegulartriangleArea.ToString("0.00"));
            Console.WriteLine($"{nameof(regularTriangle)} is orthogonal: {regularTriangle.IsOrthogonal()}");
            Console.WriteLine($"{nameof(regularTriangle)} is a regular polygon: {RegularPolygon.IsRegularPolygon(regularTriangle.GetSides())}");
            Console.WriteLine();

            RegularPolygon castedRegularTriangle = regularTriangle;
            Triangle backCastedRegularTriangle = (Triangle)castedRegularTriangle;
            double castedRegularTriangleArea = castedRegularTriangle.FindArea();
            double backCastedRegularTriangleArea = backCastedRegularTriangle.FindArea();
            Console.WriteLine($"{nameof(castedRegularTriangle)} info:\n" + castedRegularTriangle);
            Console.WriteLine($"{nameof(castedRegularTriangle)} area is: " + castedRegularTriangleArea.ToString("0.00"));
            Console.WriteLine($"{nameof(backCastedRegularTriangle)} info:\n" + backCastedRegularTriangle);
            Console.WriteLine($"{nameof(backCastedRegularTriangle)} area is: " + backCastedRegularTriangleArea.ToString("0.00"));
            Console.WriteLine($"{nameof(backCastedRegularTriangle)} is orthogonal: {backCastedRegularTriangle.IsOrthogonal()}");
            Console.WriteLine($"{nameof(backCastedRegularTriangle)} is a regular polygon: {RegularPolygon.IsRegularPolygon(backCastedRegularTriangle.GetSides())}");
            Console.WriteLine();

            Triangle orthogonalTriangle = new(3, 4, 5);
            double orthogonalTriangleArea = orthogonalTriangle.FindArea();
            Console.WriteLine($"{nameof(orthogonalTriangle)} info:\n" + orthogonalTriangle);
            Console.WriteLine($"{nameof(orthogonalTriangle)} area is: " + orthogonalTriangleArea.ToString("0.00"));
            Console.WriteLine($"{nameof(orthogonalTriangle)} is orthogonal: {orthogonalTriangle.IsOrthogonal()}");
            Console.WriteLine($"{nameof(orthogonalTriangle)} is a regular polygon: {RegularPolygon.IsRegularPolygon(orthogonalTriangle.GetSides())}");
            Console.ReadLine();
        }
    }
}
