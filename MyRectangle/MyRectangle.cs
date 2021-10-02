using System;

namespace MyRectangle
{
    /// <summary>
    /// Class <c>MyRectangle</c> represents 2D rectangle figure
    /// </summary>
    public class MyRectangle : IFigure
    {
        private readonly double _cosOfAngleToXAxis;
        private readonly Vector _fromLeftBottomToLeftTop;
        private readonly Vector _fromLeftTopToRightTop;
        private readonly Vector _fromRightTopToRightBottom;
        private readonly Vector _fromRightBottomToLeftBottom;

        /// <summary>
        /// Property to get angle beetween <c>Vector</c> of LeftBottom and LeftTop <c>Points</c> and X axis in radians
        /// </summary>
        public double Angle => Math.Acos(_cosOfAngleToXAxis);
        /// <summary>
        /// Property ti get perimeter of a <c>MyRectangle</c>
        /// </summary>
        public double Perimeter => 2 * (Width + Height);
        /// <summary>
        /// Property to get square of a <c>MyRectangle</c>
        /// </summary>
        public double Square => Width * Height;
        /// <summary>
        /// Property to get width of a <c>MyRectangle</c>
        /// </summary>
        public double Width => _fromLeftTopToRightTop.Length;
        /// <summary>
        /// Property to get height of a <c>MyRectangle</c>
        /// </summary>
        public double Height => _fromLeftBottomToLeftTop.Length;

        /// <summary>
        /// Property to get LeftBottom <c>Point</c> of a <c>MyRectangle</c>
        /// </summary>
        public Point LeftBottom => _fromLeftBottomToLeftTop.From;
        /// <summary>
        /// Property to get LeftTop <c>Point</c> of a <c>MyRectangle</c>
        /// </summary>
        public Point LeftTop => _fromLeftBottomToLeftTop.To;
        /// <summary>
        /// Property to get RightTop <c>Point</c> of a <c>MyRectangle</c>
        /// </summary>
        public Point RightTop => _fromRightTopToRightBottom.From;
        /// <summary>
        /// Property to get RightBottom <c>Point</c> of a <c>MyRectangle</c>
        /// </summary>
        public Point RightBottom => _fromRightTopToRightBottom.To;

        /// <summary>
        /// Constructor of <c>MyRectangle</c> from 4 <c>Points</c>
        /// </summary>
        /// <param name="leftBottom">LeftBottom <c>Point</c></param>
        /// <param name="leftTop">LeftTop <c>Point</c></param>
        /// <param name="rightTop">RigtTop <c>Point</c></param>
        /// <param name="rightBottom">RightBottom <c>Point</c></param>
        public MyRectangle(Point leftBottom, Point leftTop, Point rightTop, Point rightBottom) :
            this(new Vector(leftBottom, leftTop), new Vector(leftTop, rightTop),
                new Vector(rightTop, rightBottom), new Vector(rightBottom, leftBottom))
        {
            if (leftBottom.Y >= leftTop.Y || leftTop.X >= rightTop.X || rightBottom.Y >= rightTop.Y || leftBottom.X >= rightBottom.X)
            {
                throw new Exception("Points are in the wrong place");
            }
        }

        /// <summary>
        /// Constructor of <c>MyRectangle</c> from 4 <c>Vectors</c>
        /// </summary>
        /// <param name="leftVertical"><c>Vector</c> beetween LeftBottom and LeftTop <c>Points</c> of <c>MyRectangle</c></param>
        /// <param name="topHorizontal"><c>Vector</c> beetween LeftTop and RightTop <c>Points</c> of <c>MyRectangle</c></param>
        /// <param name="rightVertical"><c>Vector</c> beetween RightTop and RightBottom <c>Points</c> of <c>MyRectangle</c></param>
        /// <param name="bottomHorizontal"><c>Vector</c> beetween RightBottom and LeftBottom <c>Points</c> of <c>MyRectangle</c></param>
        public MyRectangle(Vector leftVertical, Vector topHorizontal, Vector rightVertical, Vector bottomHorizontal)
        {
            if (!leftVertical.IsPerpendecularTo(bottomHorizontal) ||
                !leftVertical.IsCollinearTo(rightVertical) ||
                !topHorizontal.IsCollinearTo(bottomHorizontal))
            {
                throw new Exception("Not a rectangle");
            }

            _cosOfAngleToXAxis = leftVertical.GetAngleBetween(VectorFactory.GetXAxisUnitVector());
            _fromLeftBottomToLeftTop = leftVertical;
            _fromLeftTopToRightTop = topHorizontal;
            _fromRightTopToRightBottom = rightVertical;
            _fromRightBottomToLeftBottom = bottomHorizontal;
        }
        /// <summary>
        /// Method to check location of a <c>Point</c> relatively to a <c>MyRectangle</c>
        /// </summary>
        /// <param name="point"><c>Point</c> to check</param>
        /// <returns>One of <c>PointLocation</c> enum value</returns>
        public PointLocation CheckLocation(Point point)
        {
           if(_fromLeftBottomToLeftTop.Contains(point) || _fromRightBottomToLeftBottom.Contains(point) ||
              _fromLeftTopToRightTop.Contains(point) || _fromRightTopToRightBottom.Contains(point))
           return PointLocation.OnTheBorder;

            var d1 = Product(point.X, point.Y, LeftBottom.X, LeftBottom.Y, LeftTop.X, LeftTop.Y);
            var d2 = Product(point.X, point.Y, LeftTop.X, LeftTop.Y, RightTop.X, RightTop.Y);
            var d3 = Product(point.X, point.Y, RightTop.X, RightTop.Y, RightBottom.X, RightBottom.Y);
            var d4 = Product(point.X, point.Y, RightBottom.X, RightBottom.Y, LeftBottom.X, LeftBottom.Y);

            if ((d1 > 0 && d2 > 0 && d3 > 0 && d4 > 0) || (d1 < 0 && d2 < 0 && d3 < 0 && d4 < 0))
            {
                return PointLocation.InFigure;
            }
            return PointLocation.OutOfFigure;
        }

        private double Product(double Px, double Py, double Ax, double Ay, double Bx, double By)
        {
            return (Bx - Ax) * (Py - Ay) - (By - Ay) * (Px - Ax);
        }

        /// <summary>
        /// Перегрузка срокового представления
        /// </summary>
        /// <returns>Строковое представление</returns>
        public override string ToString()
        {
            return string.Format("Высота: {0:f4}, Ширина: {1};\nПлощадь: {2:f4}, Периметр: {3:f4};\nУгол наклона: {4:f4}", Height, Width, Square, Perimeter, Angle * 180 / Math.PI);
        }
    }
}
