namespace MyRectangle
{
    /// <summary>
    /// Enum of possible <c>Point</c> positions relative to <c>Figure</c>
    /// </summary>
    public enum PointLocation
    {
        /// <summary>
        /// <c>Point</c> locates in figure
        /// </summary>
        InFigure,
        /// <summary>
        /// <c>Point</c> locates on the border of figure
        /// </summary>
        OnTheBorder,
        /// <summary>
        /// <c>Point</c> locates out of figure
        /// </summary>
        OutOfFigure
    }
}
