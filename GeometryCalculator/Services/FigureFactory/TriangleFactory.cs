using GeometryCalculator.Entities.Figures;

namespace GeometryCalculator.Services.FigureFactory
{
    public sealed class TriangleFactory : FigureFactoryBase
    {
        protected override bool TryCreateFigure(in float[] figureParams, out IFigure? figure)
        {
            figure = default;
            if (figureParams.Length == 3)
            {
                var triangle = GetTriangle(figureParams[0], figureParams[1], figureParams[2]);
                if (triangle.HasValidSideValues())
                {
                    figure = triangle;
                    return true;
                }
            }

            return false;
        }

        private Triangle GetTriangle(in float side1, in float side2, in float side3) => new(side1, side2, side3);
    }
}