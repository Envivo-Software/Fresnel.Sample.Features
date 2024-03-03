using Envivo.Fresnel.Bootstrap.WebServer;
using Envivo.Fresnel.Features;
using Envivo.Fresnel.Sample.Features.Model;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;

var domainModelType = typeof(ExampleBasicObject);

var app =
    new ServerApplicationBuilder()
    .WithModelAssembly(domainModelType.Assembly)
    .WithFeature(Feature.UI_DoodleMode, FeatureState.On)
    .WithServices(sc =>
    {
        sc.AddModelDependencies();
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
