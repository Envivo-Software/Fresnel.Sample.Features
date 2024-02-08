using Envivo.Fresnel.Bootstrap.WebServer;
using Envivo.Fresnel.Features;
using Envivo.Fresnel.Sample.Features.Model;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using Envivo.Fresnel.Sample.Features.Model.I_Repositories;

var domainModelType = typeof(BasicObject);

var app =
    new ServerApplicationBuilder()
    .WithModelAssembly(domainModelType.Assembly)
    .WithFeature(Feature.UI_DoodleMode, FeatureState.On)
    .WithServices(sc =>
    {
        // Because we're using InMemoryRepositories, we must use the same instance throughout:
        sc.AddSingleton<SaveableAggregateRootRepository>();
        sc.AddSingleton<SaveableEntityRepository>();
        sc.AddSingleton<AnotherAggregateRootRepository>();
        sc.AddSingleton<NestedExampleObjectRepository>();
        sc.AddSingleton<ObjectWithEagerLoadedPropertiesRepository>();
    })
    .WithPreStartupSteps(async sp =>
    {
        // This lets us setup demo data before the application starts:
        var demoInitialiser = sp.GetService<DemoInitialiser>();
        if (demoInitialiser != null)
        {
            await demoInitialiser.SetupDemoDataAsync();
        }
    })
    .Build(args);

await app.RunAsync();
