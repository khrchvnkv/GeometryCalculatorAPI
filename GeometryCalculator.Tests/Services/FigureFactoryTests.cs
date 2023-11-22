using FluentAssertions;
using GeometryCalculator.Entities.Figures;
using GeometryCalculator.Exceptions;
using GeometryCalculator.Services.FigureFactory;

namespace GeometryCalculator.Tests.Services
{
    public sealed class FigureFactoryTests
    {
        private readonly IFiguresFactory _figuresFactory;

        public FigureFactoryTests() => _figuresFactory = new FiguresFactory();

        [Fact]
        private void Handle_1RouteParam_ShouldBeReturnsCircle()
        {
            // Arrange
            var routeParams = new float[] { 1 };

            // Act
            var figure = _figuresFactory.GetFigureWithParams(routeParams);

            // Assert
            figure
                .GetType()
                .Should()
                .Be(typeof(Circle));
            
            figure
                .FigureType
                .Should()
                .Be(IFigure.FigureTypes.Circle);
        }
        
        [Fact]
        private void Handle_3RouteParams_ShouldBeReturnsTriangle()
        {
            // Arrange
            var routeParams = new float[] { 1, 1, 1 };

            // Act
            var figure = _figuresFactory.GetFigureWithParams(routeParams);

            // Assert
            figure
                .GetType()
                .Should()
                .Be(typeof(Triangle));
            
            figure
                .FigureType
                .Should()
                .Be(IFigure.FigureTypes.Triangle);
        }
        
        [Fact]
        private void Handle_NegativeRouteParams_ShouldBeThrowsException()
        {
            // Arrange
            var routeParams = new float[] { 1, 1, -1 };

            // Act && Assert
            Assert.Throws<FigureParamsFormatException>(() => _figuresFactory.GetFigureWithParams(routeParams));
        }
    }
}