using System.Drawing;

namespace TagsCloudVisualization;

public interface ICloudLayouter

{
    Rectangle PutNextRectangle(Size rectangleSize);
}

public class CircularCloudLayouter : ICloudLayouter
{
    public Point Center { get; }
    private readonly List<Rectangle> rectangles;
    private readonly ISearch spiral;

    public CircularCloudLayouter(Point center)
    {
        Center = center;
        rectangles = [];
        spiral = new ArchimedSearchSpiral(Center);
    }

    public Rectangle PutNextRectangle(Size rectangleSize)
    {
        var nextPosition = spiral.GetNextRectanglePosition(rectangleSize, rectangles);

        var rectangle = new Rectangle(nextPosition, rectangleSize);
        rectangles.Add(rectangle);
        return rectangle;
    }
}