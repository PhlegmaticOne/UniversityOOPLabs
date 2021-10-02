using System;

namespace MyRectangle
{
    /// <summary>
    /// Struct <c>Vector</c> which models vector on the plane
    /// </summary>
    public struct Vector
    {
        private readonly Point _a;
        private readonly Point _b;
        /// <summary>
        /// Property to get length module of a <c>Vector</c> based on the Pythagoras theorem
        /// </summary>
        public double Length => Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
        /// <summary>
        /// Property to get X coordinate of a <c>Vector</c>
        /// </summary>
        public double X => _b.X - _a.X;
        /// <summary>
        /// Property to get Y coordinate of a <c>Vector</c>
        /// </summary>
        public double Y => _b.Y - _a.Y;
        /// <summary>
        /// Property to get begin <c>Point</c> of a <c>Vector</c>
        /// </summary>
        public Point From => _a;
        /// <summary>
        /// Property to get end <c>Point</c> of a <c>Vector</c>
        /// </summary>
        public Point To => _b;
        /// <summary>
        /// Конструктор
        /// </summary>
        public Vector(Point a, Point b) => (_a, _b) = (a, b);
        /// <summary>
        /// Method which counts angle beetween two <c>Vectors</c>
        /// </summary>
        /// <param name="vector"><c>Vector</c> with which it is necessary to find an angle</param>
        /// <returns>Cos(a), where a - angle beetween two <c>Vectors</c> in radians</returns>
        public double GetAngleBetween(Vector vector) => ScalarMultiply(vector) / (Length * vector.Length);
        /// <summary>
        /// Method which checks if a <c>Vector</c> is perpendicular to a given <c>Vector</c>
        /// </summary>
        /// <param name="vector"><c>Vector</c> to check</param>
        /// <returns>true - <c>Vectors</c> are perpendicular, false - they are not</returns>
        public bool IsPerpendecularTo(Vector vector) => GetAngleBetween(vector) == 0;
        /// <summary>
        /// Method which checks if a <c>Vector</c> is collinear to a given <c>Vector</c>
        /// </summary>
        /// <param name="vector"><c>Vector</c> to check</param>
        /// <returns>true - <c>Vectors</c> are collinear, false - they are not</returns>
        public bool IsCollinearTo(Vector vector)
        {
            var angle = Math.Round(GetAngleBetween(vector), 4);
            return angle == 1 || angle == -1;
        }
        /// <summary>
        /// Method which counts scalar multiply of two <c>Vectors</c>
        /// </summary>
        /// <param name="other"><c>Vectors</c> with which it is necssary to find scalar multiply</param>
        /// <returns>Scalar multiply</returns>
        public double ScalarMultiply(Vector other) => other.X * X + other.Y * Y;
        /// <summary>
        /// Перегрузка сравнения
        /// </summary>
        /// <returns>true - равны</returns>
        public override bool Equals(object obj) => (obj is Vector vector) ?
                                                    Length == vector.Length && IsCollinearTo(vector) && Math.Sign(X) == Math.Sign(vector.X)
                                                    : false;
        /// <summary>
        /// Перегрузка хэширования
        /// </summary>
        /// <returns>Хэш</returns>
        public override int GetHashCode() => X.GetHashCode() + Y.GetHashCode();
        /// <summary>
        /// Перегрузка строкового представления
        /// </summary>
        /// <returns>Строковое представление</returns>
        public override string ToString() => string.Format("[{0}, {1}]", X, Y);
    }
}
