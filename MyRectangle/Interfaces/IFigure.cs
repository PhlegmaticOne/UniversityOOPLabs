namespace MyRectangle
{
    /// <summary>
    /// Common figure interface
    /// </summary>
    public interface IFigure
    {
        /// <summary>
        /// Property to get square of the figure
        /// </summary>
        double Perimeter { get; }
        /// <summary>
        /// Property to get perimeter of the figure
        /// </summary>
        double Square { get; }
    }
}
