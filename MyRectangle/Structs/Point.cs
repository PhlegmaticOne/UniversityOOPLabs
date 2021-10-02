using System;

namespace MyRectangle
{
    /// <remarks><c>Point</c> struct which models point on the plane</remarks>
    public struct Point
    {
        private readonly double _x;
        private readonly double _y;
        /// <summary>
        /// Property to get X coordinate of <c>Point</c>
        /// </summary>
        public double X => _x;
        /// <summary>
        /// Property to get Y coordinate of <c>Point</c>
        /// </summary>
        public double Y => _y;
        public Point(double x, double y) => (_x, _y) = (x, y);
        /// <summary>
        /// Overloaded multiply <c>Point</c> by constant operator
        /// </summary>
        /// <param name="a">Point to multiply</param>
        /// <param name="k">Constant to multiply</param>
        /// <returns>Новая точка с координатами увеличенными в <c>k</c> раз</returns>
        public static Point operator *(Point a, double k) => new Point(k * a._x, k * a._y);
        /// <summary>
        /// Overloaded GT operator for <c>Point</c>
        /// </summary>
        /// <param name="a">Fisrt <c>Point</c> to compare</param>
        /// <param name="b">Second <c>Point</c> to compare</param>
        /// <returns>true - distance from origin to the first <c>Point</c> is greater than to second <c>Point</c>, false - contrawise</returns>
        public static bool operator >(Point a, Point b) => new Vector(new Point(0, 0), a).Length > new Vector(new Point(0, 0), b).Length;
        /// <summary>
        /// Overloaded LT operator for <c>Point</c>
        /// </summary>
        /// <param name="a">Fisrt <c>Point</c> to compare</param>
        /// <param name="b">Second <c>Point</c> to compare</param>
        /// <returns>true - distance from origin to the first <c>Point</c> is less than to second <c>Point</c>, false - contrawise</returns>
        public static bool operator <(Point a, Point b) => !(a > b);
        public override bool Equals(object obj) => (obj is Point point) ? point.X == _x && point.Y == _y : false;
        public override int GetHashCode() => _x.GetHashCode() + _y.GetHashCode();
        public override string ToString() => String.Format("({0}, {1})", _x, _y);
    }
}
