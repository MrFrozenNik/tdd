using System.Drawing;

namespace TagsCloudVisualization;

public interface ICloudLayouter

{
    Rectangle PutNextRectangle(Size rectangleSize);
}


public class CircularCloudLayouter : ICloudLayouter
{
    public CircularCloudLayouter(Point center)
    {
        
    }

    public Rectangle PutNextRectangle(Size rectangleSize)
    {
        throw new NotImplementedException();
    }
}