using Envivo.Fresnel.Bootstrap.WebServer;
using Envivo.Fresnel.Features;
using Envivo.Fresnel.Sample.Features.Model;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;

var builder = WebApplication.CreateBuilder(args);

builder.AddFresnel(opt =>
{
    opt
    .WithModelAssemblyFrom<ExampleBasicObject>()
    .WithFeature(Feature.UI_DoodleMode, FeatureState.On)
    .WithDefaultFileLogging();

    builder.Services.AddLogging();

    builder.Services.AddModelDependencies();
});

var app = builder.Build();

app.UseFresnel();

// Antiforgery must come at the end.
// See https://github.com/dotnet/aspnetcore/issues/49654#issuecomment-1654754907
app.UseHttpsRedirection();
app.UseAntiforgery();

// Setup demo data before the application starts:
var demoInitialiser = app.Services.GetService<DemoInitialiser>();
if (demoInitialiser != null)
{
    await demoInitialiser.SetupDemoDataAsync();
}

await app.RunAsync();
