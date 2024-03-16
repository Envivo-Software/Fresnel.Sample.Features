using Envivo.Fresnel.Sample.Features.Model.A_Objects.ValueObjects.Dependencies;
using Envivo.Fresnel.Sample.Features.Model.I_Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Envivo.Fresnel.Sample.Features.Model
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddModelDependencies(this IServiceCollection sc)
        {
            // Because we're using InMemoryRepositories, we must use the same instance throughout:
            sc.AddSingleton<SaveableAggregateRootRepository>();
            sc.AddSingleton<SaveableEntityRepository>();
            sc.AddSingleton<ExampleAggregateRootRepository>();
            sc.AddSingleton<ExampleOfNestedObjectsRepository>();
            sc.AddSingleton<ExamplesOfEagerLoadedPropertiesRepository>();
            sc.AddSingleton<ExampleCustomerRepository>();
            sc.AddSingleton<ExampleImmutableObjectRepository>();
            sc.AddSingleton<ExampleImmutablePropertiesRepository>();

            return sc;
        }
    }
}
