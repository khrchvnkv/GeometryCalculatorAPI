namespace GeometryCalculator.Entities.Figures
{
    public sealed class Circle : IFigure
    {
        private readonly float _radius;
        
        public IFigure.FigureTypes FigureType => IFigure.FigureTypes.Circle;

        public Circle(float radius)
        {
            if (radius < 0.0f) throw new ArgumentException("The radius of a circle cannot be negative");
            
            _radius = radius;
        }

        public float GetAreaValue() => MathF.PI * MathF.Pow(_radius, 2);
    }
}