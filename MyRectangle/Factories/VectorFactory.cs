namespace MyRectangle
{
    /// <summary>
    /// Factory for a certain <c>Vector</c> types
    /// </summary>
    public class VectorFactory
    {
        /// <summary>
        /// Method to get X axis unit <c>Vector</c>
        /// </summary>
        /// <returns>X axis unit <c>Vector</c> </returns>
        public static Vector GetXAxisUnitVector() => new Vector(new Point(0, 0), new Point(1, 0));
        /// <summary>
        /// Method to get Y axis unit <c>Vector</c>
        /// </summary>
        /// <returns>Y axis unit <c>Vector</c> </returns>
        public static Vector GetYAxisUnitVector() => new Vector(new Point(0, 0), new Point(0, 1));
    }
}
