namespace GeometryCalculator.Entities.Figures
{
    public interface IFigure
    {
        public FigureTypes FigureType { get; }
        
        public enum FigureTypes
        {
            Circle,
            Triangle
        }
        
        float GetAreaValue();
    }
}