using System.Linq;

namespace SquareMatrix.Lab3
{
    public static class SquareMatrixExtensions
    {
        public static double Max(this SquareMatrix matrix)
        {
            double max = double.MinValue;
            foreach (var row in matrix.GetRows())
            {
                var potMax = row.Max();
                max = (potMax > max) ? potMax : max;
            }
            return max;
        }

        public static double Min(this SquareMatrix matrix)
        {
            double min = double.MaxValue;
            foreach (var row in matrix.GetRows())
            {
                var potMin = row.Min();
                min = (potMin < min) ? potMin : min;
            }
            return min;
        }
    }
}
