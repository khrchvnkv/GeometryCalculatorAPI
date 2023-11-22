using GeometryCalculator.Entities.Figures;
using GeometryCalculator.Exceptions;

namespace GeometryCalculator.Services.FigureFactory
{
    public sealed class FiguresFactory : IFiguresFactory
    {
        private readonly IFigureFactoryChain _figureFactoriesChain;

        public FiguresFactory()
        {
            var circleFactory = new CircleFactory();
            var triangleFactory = new TriangleFactory();
            
            circleFactory.SetNextFactoryChain(triangleFactory);
            _figureFactoriesChain = circleFactory;
        }

        public IFigure? GetFigureWithParams(in float[] figureParams)
        {
            if (IsFigureParamsCorrect(figureParams))
            {
                return _figureFactoriesChain.GetFigure(figureParams);
            }

            throw new FigureParamsFormatException("Route parameters must not be negative");
        }
        
        private bool IsFigureParamsCorrect(in float[] figureParams) => figureParams.All(x => x >= 0.0f);
    }
}