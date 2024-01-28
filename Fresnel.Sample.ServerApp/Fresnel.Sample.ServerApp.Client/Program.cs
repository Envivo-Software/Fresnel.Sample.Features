using Envivo.Fresnel.Bootstrap.WebAssembly;
using Envivo.Fresnel.Features;
using Envivo.Fresnel.Sample.Features.Model;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using Envivo.Fresnel.Sample.Features.Model.I_Repositories;

// THIS EXECUTES IN THE BROWSER, NOT ON THE SERVER!!

Type myDomainClass = typeof(BasicObject);

var app =
    new WebAssemblyHostBuilder()
    .WithModelAssembly(myDomainClass.Assembly)
    .WithFeature(Feature.UI_DoodleMode, FeatureState.Off)
    .WithServices(sc =>
    {
        // Because we're using InMemoryRepositories, we must use the same instance throughout:
        sc.AddSingleton<SaveableAggregateRootRepository>();
        sc.AddSingleton<SaveableEntityRepository>();
        sc.AddSingleton<AnotherAggregateRootRepository>();
        sc.AddSingleton<NestedExampleObjectRepository>();
    })
    .WithPreStartupSteps(async sp =>
    {
        // This let's up setup demo data before the application starts:
        var demoInitialiser = sp.GetService<DemoInitialiser>();
        if (demoInitialiser != null)
        {
            await demoInitialiser.SetupDemoDataAsync();
        }
    })
    .Build();

await app.RunAsync();
