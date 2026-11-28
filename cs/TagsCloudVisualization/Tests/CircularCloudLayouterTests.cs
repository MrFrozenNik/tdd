using System.Drawing;
using NUnit.Framework;
using FluentAssertions;

namespace TagsCloudVisualization.Tests;

[TestFixture]
public class CircularCloudLayouterTests
{
    [Test]
    public void CircularCloudLayouter_PlacesFirstRectangle()
    {
        //Arrange
        var center = new Point();
        var layouter = new CircularCloudLayouter(center);
        var size = new Size(1, 1);

        //Act
        var rectangle = layouter.PutNextRectangle(size);

        //Assert
        rectangle.X.Should().Be(0);
        rectangle.Y.Should().Be(0);
        rectangle.Height.Should().Be(1);
        rectangle.Width.Should().Be(1);
    }
}