namespace GeometryCalculator.Tests.Entities.Circle
{
    public sealed class CircleTests
    {
        [Fact]
        private void Create_CircleWithNegativeRadius_ShouldBeThrowsException()
        {
            // Arrange && Act && Assert
            Assert.Throws<ArgumentException>(() => new GeometryCalculator.Entities.Figures.Circle(-1));
        }
    }
}