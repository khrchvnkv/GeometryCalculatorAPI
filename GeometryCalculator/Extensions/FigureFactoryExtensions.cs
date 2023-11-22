using GeometryCalculator.Services.FigureFactory;

namespace GeometryCalculator.Extensions
{
    public static class FigureFactoryExtensions
    {
        public static IServiceCollection AddFiguresFactory(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IFiguresFactory, FiguresFactory>();
            return serviceCollection;
        }
    }
}