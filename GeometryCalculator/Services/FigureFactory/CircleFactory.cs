using GeometryCalculator.Entities.Figures;

namespace GeometryCalculator.Services.FigureFactory
{
    public sealed class CircleFactory : FigureFactoryBase
    {
        protected override bool TryCreateFigure(in float[] figureParams, out IFigure? figure)
        {
            figure = default;
            if (figureParams.Length == 1)
            {
                figure = GetCircle(figureParams[0]);
                return true;
            }

            return false;
        }

        private Circle GetCircle(in float radius) => new(radius);
    }
}