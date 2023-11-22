using GeometryCalculator.Entities.Figures;

namespace GeometryCalculator.Services.FigureFactory
{
    public interface IFigureFactoryChain
    {
        void SetNextFactoryChain(in FigureFactoryBase nextFactoryBaseChain);
        IFigure? GetFigure(in float[] figureParams);
    }
}