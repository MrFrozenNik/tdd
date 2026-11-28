using System.Drawing;

namespace TagsCloudVisualization;

public interface ICloudLayouter

{
    Rectangle PutNextRectangle(Size rectangleSize);
}


public class CircularCloudLayouter : ICloudLayouter
{
    public Point Center { get; private set; }
    private IList<Rectangle> rectangles;

    public CircularCloudLayouter(Point center)
    {
        Center = center;
        rectangles = new List<Rectangle>();
    }

    public Rectangle PutNextRectangle(Size rectangleSize)
    {
        var rectangle = new Rectangle(Center, rectangleSize);
        rectangles.Add(rectangle);
        return rectangle;
    }
}