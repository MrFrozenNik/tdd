using System.Collections;
using System.Drawing;
using NUnit.Framework;
using FluentAssertions;

namespace TagsCloudVisualization.Tests;

[TestFixture]
public class CircularCloudLayouterTests
{
    [TestCase(0, 0, 1, 1)]
    [TestCase(100, 200, 35, 8)]
    public void CircularCloudLayouter_PlacesFirstRectangle(int x, int y, int width, int height)
    {
        //Arrange
        var zeroCenter = new Point(x, y);
        var layouter = new CircularCloudLayouter(zeroCenter);
        var size = new Size(width, height);

        //Act
        var rectangle = layouter.PutNextRectangle(size);

        //Assert
        rectangle.Should().Be(new Rectangle(x, y, width, height));
    }


    private static IEnumerable TwoRectanglesCases
    {
        get
        {
            yield return new TestCaseData(new Size(1, 1), new Size(1, 1)).SetName("Two simple rectangles");
        }
    }
    
    
    [TestCaseSource(nameof(TwoRectanglesCases))]
    public void PutNextRectangle_DoesNotOverlapsFirstRectangle(Size size1, Size size2)
    {
        //Arrange
        var zeroCenter = new Point();
        var layouter = new CircularCloudLayouter(zeroCenter);
        var firstRectangle = layouter.PutNextRectangle(size1);
        
        //Act
        var secondRectange = layouter.PutNextRectangle(size2);
        
        firstRectangle.IntersectsWith(secondRectange).Should().Be(false);
    }
    
    
}