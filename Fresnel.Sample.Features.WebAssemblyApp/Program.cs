using Envivo.Fresnel.Bootstrap.WebAssembly;
using Envivo.Fresnel.Features;
using Envivo.Fresnel.Sample.Features.Model;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using WebAssemblyHostBuilder = Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.AddFresnel(opt =>
{
    opt
    .WithModelAssemblyFrom<ExampleBasicObject>()
    .WithFeature(Feature.UI_DoodleMode, FeatureState.On)
    .WithDefaultFileLogging();

    builder.Services.AddModelDependencies();
});

var host = builder.Build();

host.UseFresnel();

// Setup demo data before the application starts:
var demoInitialiser = host.Services.GetService<DemoInitialiser>();
if (demoInitialiser != null)
{
    await demoInitialiser.SetupDemoDataAsync();
}

await host.RunAsync();
