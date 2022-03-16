using MonthlyCalculatorAPI.Utilities.IoC;

namespace MonthlyCalculatorAPI.Utilities.Helpers.Extensions
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers
            (this IServiceCollection serviceCollection, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }

            return ServiceTool.Create(serviceCollection);
        }
    }
}
