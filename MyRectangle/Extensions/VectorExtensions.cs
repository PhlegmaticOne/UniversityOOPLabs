using System;

namespace MyRectangle
{
    /// <summary>
    /// Class with extension methods for a <c>Vector</c> type
    /// </summary>
    public static class VectorExtensions
    {
        /// <summary>
        /// Method for checking the location of a <c>Point</c> on a <c>Vector</c>
        /// </summary>
        /// <param name="vector"><c>Vector</c> being checked</param>
        /// <param name="point"><c>Point</c> being checked</param>
        /// <returns>true - <c>Point</c> is on a <c>Vector</c>, false - it is not</returns>
        public static bool Contains(this Vector vector, Point point)
        {
            var a = vector.From;
            var b = vector.To;
            if (a.X < b.X && (point.X < a.X || point.X > b.X)) return false;
            else if (a.X > b.X && (point.X > a.X || point.X < b.X)) return false;

            if (a.X == b.X && point.X == a.X)
            {
                return (a.Y > b.Y) ? (point.Y <= a.Y && point.Y >= b.Y) : (point.Y >= a.Y && point.Y <= b.Y);
            }
            if (a.Y == b.Y && point.Y == a.Y)
            {
                return (a.X > b.X) ? (point.X <= a.X && point.X >= b.X) : (point.X >= a.X && point.X <= b.X);
            }
            var k = (a.Y - b.Y) / (a.X - b.X);
            var c = (a.X * b.Y - a.Y * b.X) / (a.X - b.X);
            return Math.Round(point.Y, 4) == Math.Round(k * point.X + c, 4);
        }
    }
}
