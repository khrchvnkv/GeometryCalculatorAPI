namespace GeometryCalculator.Entities.Figures
{
    public sealed class Triangle : IFigure
    {
        private const int RoundingToDigitsPlaces = 5;

        private readonly float _side1;
        private readonly float _side2;
        private readonly float _side3;
        
        public IFigure.FigureTypes FigureType => IFigure.FigureTypes.Triangle;

        public Triangle(float side1, float side2, float side3)
        {
            var sortedCollection = new List<float> { side1, side2, side3 };
            if (sortedCollection.Any(x => x < 0.0f))
                throw new ArgumentException("The sides of a triangle cannot be negative");
            
            sortedCollection.Sort();
            _side1 = sortedCollection[0];
            _side2 = sortedCollection[1];
            _side3 = sortedCollection[2];
        }
        
        public float GetAreaValue()
        {
            var perimeterHalf = (_side1 + _side2 + _side3) / 2.0f;
            var area = MathF.Sqrt(perimeterHalf * (perimeterHalf - _side1) * (perimeterHalf - _side2) *
                                  (perimeterHalf - _side3));
            
            return area;
        }
        
        public bool HasValidSideValues() => _side1 + _side2 >= _side3;
        
        public bool IsRectangularTriangle()
        {
            return MathF.Round(SideSqr(_side1) + SideSqr(_side2), RoundingToDigitsPlaces) == 
                   MathF.Round(SideSqr(_side3), RoundingToDigitsPlaces);
            
            float SideSqr(float side) => MathF.Pow(side, 2);
        }
    }
}