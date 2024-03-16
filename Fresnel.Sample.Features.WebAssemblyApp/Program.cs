using Envivo.Fresnel.Bootstrap.WebAssembly;
using Envivo.Fresnel.Features;
using Envivo.Fresnel.Sample.Features.Model;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;

Type myDomainClass = typeof(ExampleBasicObject);

var app =
    new WebAssemblyHostBuilder()
    .WithModelAssembly(myDomainClass.Assembly)
    .WithFeature(Feature.UI_DoodleMode, FeatureState.On)
    .WithServices(sc =>
    {
        sc.AddModelDependencies();
    })
    .WithFileLogging()
    .WithPreStartupSteps(async sp =>
    {
        // This lets us setup demo data before the application starts:
        var demoInitialiser = sp.GetService<DemoInitialiser>();
        if (demoInitialiser != null)
        {
            await demoInitialiser.SetupDemoDataAsync();
        }
    })
    .Build();

await app.RunAsync();
