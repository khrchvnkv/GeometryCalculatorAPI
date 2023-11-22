using FluentAssertions;

namespace GeometryCalculator.Tests.Entities.Triangle
{
    public sealed class TriangleTests
    {
        [Fact]
        private void Create_TriangleWithNegativeParams_ShouldBeThrowsException()
        {
            // Arrange && Act && Assert
            Assert.Throws<ArgumentException>(() => new GeometryCalculator.Entities.Figures.Triangle(1, 1, -1));
        }
        
        [Fact]
        public void Create_TriangleWithValidSides_ShouldReturnsTriangleHasValidSidesTrue()
        {
            // Arrange
            var figure = new GeometryCalculator.Entities.Figures.Triangle(1, 1, 1);

            // Act
            var hasValidSideValues = figure.HasValidSideValues();

            // Assert
            hasValidSideValues
                .Should()
                .Be(true);
        }
        
        [Fact]
        public void Create_TriangleWithInvalidSides_ShouldReturnsTriangleHasValidSidesFalse()
        {
            // Arrange
            var figure = new GeometryCalculator.Entities.Figures.Triangle(1, 1, 5);

            // Act
            var hasValidSideValues = figure.HasValidSideValues();

            // Assert
            hasValidSideValues
                .Should()
                .Be(false);
        }
        
        [Fact]
        public void Create_RectangularTriangle_ShouldReturnsIsRectangularTrue()
        {
            // Arrange
            var figure = new GeometryCalculator.Entities.Figures.Triangle(3, 4, 5);
            
            // Act
            var isRectangular = figure.IsRectangularTriangle();
            
            // Assert
            isRectangular
                .Should()
                .Be(true);
        }
        
        [Fact]
        public void Create_NonRectangularTriangle_ShouldReturnsIsRectangularFalse()
        {
            // Arrange
            var figure = new GeometryCalculator.Entities.Figures.Triangle(3, 3, 3);
            
            // Act
            var isRectangular = figure.IsRectangularTriangle();
            
            // Assert
            isRectangular
                .Should()
                .Be(false);
        }
    }
}