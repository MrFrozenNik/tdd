using System.Drawing;

namespace TagsCloudVisualization;

interface ISearch
{
    public Point GetNextRectanglePosition(Size rectangleSize, IReadOnlyList<Rectangle> placedRectangles);
}

public class ArchimedSearchSpiral(Point spiralCenter) : ISearch
{
    public PointF SpiralCenter { get; } = spiralCenter;
    private const double SearchStepPixels = 2.0;

    public Point GetNextRectanglePosition(Size rectangleSize, IReadOnlyList<Rectangle> placedRectangles)
    {
        if (placedRectangles.Count == 0) return GetRectangleLeftTop(SpiralCenter, rectangleSize);

        var turnSpacing = Math.Min(rectangleSize.Width, rectangleSize.Height) / 2.0;
        var radialGrowthPerRadian = turnSpacing / (2 * Math.PI);
        var angleRadians = Math.PI * 0;

        var radial = radialGrowthPerRadian * angleRadians;
        var spiralPoint = GetSpiralPoint(radial, angleRadians);

        Point rectangleLeftTop;
        do
        {
            rectangleLeftTop = GetRectangleLeftTop(spiralPoint, rectangleSize);

            var deltaAngle = SearchStepPixels / Math.Sqrt(radialGrowthPerRadian * radialGrowthPerRadian + radial * radial);
            angleRadians += deltaAngle;
            spiralPoint = GetSpiralPoint(radial, angleRadians);
            radial = radialGrowthPerRadian * angleRadians;
        } while (placedRectangles.Any(r => r.IntersectsWith(new Rectangle(rectangleLeftTop, rectangleSize))));


        return rectangleLeftTop;
    }

    private PointF GetSpiralPoint(double radial, double angle)
    {
        var x = SpiralCenter.X + radial * Math.Cos(angle);
        var y = SpiralCenter.Y + radial * Math.Sin(angle);
        return new PointF((float)x, (float)y);
    }

    private static Point GetRectangleLeftTop(PointF spiralPoint, Size rectangleSize) =>
        new()
        {
            X = (int)Math.Round(spiralPoint.X - rectangleSize.Width / 2.0),
            Y = (int)Math.Round(spiralPoint.Y - rectangleSize.Height / 2.0)
        };
}