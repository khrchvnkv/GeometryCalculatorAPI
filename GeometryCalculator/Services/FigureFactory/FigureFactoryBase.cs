using GeometryCalculator.Entities.Figures;
using GeometryCalculator.Exceptions;

namespace GeometryCalculator.Services.FigureFactory
{
    public abstract class FigureFactoryBase : IFigureFactoryChain
    {
        private IFigureFactoryChain? _nextFactoryChain;
        
        public void SetNextFactoryChain(in FigureFactoryBase nextFactoryBaseChain)
        {
            if (nextFactoryBaseChain == this) throw new ArgumentException("The chain should not create a closed loop");
            _nextFactoryChain = nextFactoryBaseChain;
        }

        public IFigure? GetFigure(in float[] figureParams)
        {
            if (TryCreateFigure(figureParams, out var figure)) return figure;
            if (_nextFactoryChain is not null) return _nextFactoryChain.GetFigure(figureParams);

            throw new FigureParamsFormatException("Failed to create figure with route parameters");
        }

        protected abstract bool TryCreateFigure(in float[] figureParams, out IFigure? figure);
    }
}