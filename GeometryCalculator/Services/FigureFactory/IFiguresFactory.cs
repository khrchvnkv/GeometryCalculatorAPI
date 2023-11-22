using GeometryCalculator.Entities.Figures;

namespace GeometryCalculator.Services.FigureFactory
{
    public interface IFiguresFactory
    {
        IFigure? GetFigureWithParams(in float[] figureParams);
    }
}