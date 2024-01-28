using Autofac;
using Autofac.Extensions.DependencyInjection;
using Envivo.Fresnel.Bootstrap;
using Envivo.Fresnel.Features;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using Envivo.Fresnel.UI.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// The Microsoft.Extensions.Logging package provides this one-liner
// to add logging services.
builder.Services.AddLogging();

builder.Services.AddFresnel();

{
    // Add services to the container:
    // See https://stackoverflow.com/a/69788937/80369
    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

    builder.Host.ConfigureContainer<ContainerBuilder>(autofacContainerBuilder =>
    {
        new FresnelContainerBuilder()
            .WithModelAssemblyFrom<BasicObject>()
            .WithServices(builder.Services)
            .WithFeature(Feature.Deployment_WebServer, FeatureState.On)
            .InitialiseServiceCollection()
            .ConfigureContainer(autofacContainerBuilder);
    });
}
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App2>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode();

app.Run();
